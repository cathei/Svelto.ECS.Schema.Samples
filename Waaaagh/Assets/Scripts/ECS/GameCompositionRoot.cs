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
            var indexedDB = _enginesRoot.GenerateIndexedDB();
            var schema = _enginesRoot.AddSchema<GameSchema>(indexedDB);

            var movementEngine = new ApplyMovementEngine(indexedDB, schema);
            var damageEngine = new ApplyDamageEngine(indexedDB, schema);

            var tickableEnginesGroup = new TickableEnginesGroup(new FasterList<IStepEngine>(new IStepEngine[] 
            {
                movementEngine,
                damageEngine,
            }));

            _gameLoop = GameLoop.Create(_simpleSubmitScheduler, tickableEnginesGroup);
        }

        public void OnContextDestroyed(bool hasBeenInitialised)
        {
            _gameLoop.Dispose();
        }
    }

    public class TickableEnginesGroup : UnsortedEnginesGroup<IStepEngine>
    {
        public TickableEnginesGroup(FasterList<IStepEngine> engines) : base(engines) { }
    }
}
