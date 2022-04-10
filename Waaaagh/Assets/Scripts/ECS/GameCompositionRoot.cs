using System;
using System.Collections.Generic;
using Svelto.Context;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schedulers;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;
using UnityEngine;

namespace Cathei.Waaagh
{
    public class GameCompositionRoot : ICompositionRoot
    {
        private SimpleEntitiesSubmissionScheduler _simpleSubmitScheduler;
        private EnginesRoot _enginesRoot;

        private FasterList<ITickEngine> _tickEngines;

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

            _tickEngines = new FasterList<ITickEngine>();

            TargetingLayerComposition.Compose(AddEngine, indexedDB, schema.Targeted);
            MovementLayerComposition.Compose(AddEngine, indexedDB);
            DamageLayerComposition.Compose(AddEngine, indexedDB, schema.Damaged);
            StatusLayerComposition.Compose(AddEngine, indexedDB);
            SpawningLayerComposition.Compose(AddEngine, indexedDB);
            GameObjectLayerComposition.Compose(AddEngine, indexedDB, designsDB, schema.Damaged);

            _tickEngines.Add(new StepEngineAsTickEngine(indexedDB));

            var tickableEnginesGroup = new TickEnginesGroup(_tickEngines);

            _enginesRoot.AddEngine(tickableEnginesGroup);

            BuildInitialEntities(entityFactory, schema);

            _gameLoop = GameLoop.Create(_simpleSubmitScheduler, tickableEnginesGroup);
        }

        private void AddEngine(IEngine engine)
        {
            _enginesRoot.AddEngine(engine);

            if (engine is ITickEngine tickEngine)
                _tickEngines.Add(tickEngine);
        }

        public void OnContextDestroyed(bool hasBeenInitialised)
        {
            if (hasBeenInitialised)
            {
                _gameLoop.Dispose();
                _enginesRoot.Dispose();
            }
        }

        private Vector3 GetRandomPosition()
        {
            return new(
                UnityEngine.Random.Range(-5f, 5f),
                UnityEngine.Random.Range(-5f, 5f),
                0);
        }

        private void BuildInitialEntities(IEntityFactory factory, GameSchema schema)
        {
            for (uint i = 0; i < 100; ++i)
            {
                var builder = factory.Build(schema.Guardman, i);
                builder.Init(new PositionComponent(GetRandomPosition()));
            }

            for (uint i = 0; i < 100; ++i)
            {
                var builder = factory.Build(schema.Orcs, i);
                builder.Init(new PositionComponent(GetRandomPosition()));
            }
        }
    }

    public class StepEngineAsTickEngine : ITickEngine
    {
        private readonly IStepEngine _engine;

        public StepEngineAsTickEngine(IStepEngine engine)
        {
            _engine = engine;
        }

        public string name => _engine.name;

        public void Step(in float _param)
        {
            _engine.Step();
        }
    }

    public class TickEnginesGroup : UnsortedEnginesGroup<ITickEngine, float>
    {
        public TickEnginesGroup(FasterList<ITickEngine> engines) : base(engines) { }
    }
}
