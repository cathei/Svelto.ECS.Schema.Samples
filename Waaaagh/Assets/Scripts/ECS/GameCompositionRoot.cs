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

        private FasterList<ITickEngine> _tickableEngines;

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

            _tickableEngines = new FasterList<ITickEngine>();

            TargetingLayerComposition.Compose(AddEngine, indexedDB, schema.Targeted);
            MovementLayerComposition.Compose(AddEngine, indexedDB);
            DamageLayerComposition.Compose(AddEngine, indexedDB, schema.Damaged);
            StatusLayerComposition.Compose(AddEngine, indexedDB);
            SpawningLayerComposition.Compose(AddEngine, indexedDB);
            GameObjectLayerComposition.Compose(AddEngine, indexedDB, designsDB, schema.Damaged);

            var tickableEnginesGroup = new TickEnginesGroup(indexedDB, _tickableEngines);

            _enginesRoot.AddEngine(tickableEnginesGroup);

            _gameLoop = GameLoop.Create(_simpleSubmitScheduler, tickableEnginesGroup);
        }

        private void AddEngine(IEngine engine)
        {
            _enginesRoot.AddEngine(engine);

            if (engine is ITickEngine tickEngine)
                _tickableEngines.Add(tickEngine);
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


    public class TickEnginesGroup : UnsortedEnginesGroup<ITickEngine, float>
    {
        private readonly IndexedDB _indexedDB;

        public TickEnginesGroup(IndexedDB indexedDB, FasterList<ITickEngine> engines)
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
