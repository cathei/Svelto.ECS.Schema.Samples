using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public class ApplyMovementEngine : IStepEngine<float>
    {
        private readonly IndexedDB _indexedDB;
        private readonly GameSchema _schema;

        public string name => nameof(ApplyMovementEngine);

        public ApplyMovementEngine(IndexedDB indexedDB, GameSchema schema)
        {
            _indexedDB = indexedDB;
            _schema = schema;
        }

        public void Step(float deltaTime)
        {
            foreach (var result in _indexedDB.Select<MovableSet>().FromAll())
            {
                foreach (var i in result.indices)
                {
                    ref var position = ref result.set.position[i];
                    ref var velocity = ref result.set.velocity[i];

                    position.value += velocity.value * deltaTime;

                }

            }
        }
    }
}
