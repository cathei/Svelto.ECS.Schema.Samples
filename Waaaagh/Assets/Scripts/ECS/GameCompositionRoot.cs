using System;
using System.Collections.Generic;
using Svelto.Context;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schedulers;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;

namespace Cathei.Waaagh
{
    public class GameCompositionRoot : ICompositionRoot
    {
        private SimpleEntitiesSubmissionScheduler _simpleSubmitScheduler;
        private EnginesRoot _enginesRoot;

        private GameLoop _gameLoop;

        public void OnContextCreated<T>(T contextHolder)
        {
            _simpleSubmitScheduler = new SimpleEntitiesSubmissionScheduler();
            _enginesRoot = new EnginesRoot(_simpleSubmitScheduler);
        }

        public void OnContextInitialized<T>(T contextHolder)
        {
            var gameContext = contextHolder as GameContext;
            var designsDB = gameContext.designsDB;

            var entityFactory = _enginesRoot.GenerateEntityFactory();
            var indexedDB = _enginesRoot.GenerateIndexedDB();
            var schema = _enginesRoot.AddSchema<GameSchema>(indexedDB);

            var goManager = new GameObjectResourceManager(designsDB);

            var applyMovementEngine = new ApplyMovementEngine(indexedDB);
            var applyDamageEngine = new ApplyDamageEngine(indexedDB);

            _enginesRoot.AddEngine(applyMovementEngine);
            _enginesRoot.AddEngine(applyDamageEngine);

            var damageFeedbackEngine = new DamageFeedbackEngine(indexedDB, schema);

            _enginesRoot.AddEngine(damageFeedbackEngine);

            var gameObjectSpawnEngine = new GameObjectSpawnEngine(indexedDB, goManager);
            var gameObjectSyncEngine = new GameObjectSyncEngine(indexedDB, goManager);

            _enginesRoot.AddEngine(gameObjectSpawnEngine);
            _enginesRoot.AddEngine(gameObjectSyncEngine);

            var tickableEnginesGroup = new TickableEnginesGroup(indexedDB, new(new IStepEngine<float>[]
            {
                applyMovementEngine,
                applyDamageEngine,
                damageFeedbackEngine,
                gameObjectSyncEngine,
            }));

            _enginesRoot.AddEngine(tickableEnginesGroup);

            _gameLoop = GameLoop.Create(_simpleSubmitScheduler, tickableEnginesGroup);
        }

        public void OnContextDestroyed(bool hasBeenInitialised)
        {
            if (hasBeenInitialised)
            {
                _gameLoop.Dispose();
                _enginesRoot.Dispose();
            }
        }
    }

    public class TickableEnginesGroup : UnsortedEnginesGroup<IStepEngine<float>, float>
    {
        private readonly IndexedDB _indexedDB;

        public TickableEnginesGroup(IndexedDB indexedDB, FasterList<IStepEngine<float>> engines)
            : base(engines)
        {
            _indexedDB = indexedDB;
        }

        public new void Step(in float deltaTime)
        {
            base.Step(deltaTime);

            _indexedDB.Step();
        }
    }
}
