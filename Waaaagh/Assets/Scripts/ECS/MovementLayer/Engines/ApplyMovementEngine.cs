using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    internal class ApplyMovementEngine : ITickEngine
    {
        private readonly IndexedDB _indexedDB;

        public string name => nameof(ApplyMovementEngine);

        public ApplyMovementEngine(IndexedDB indexedDB)
        {
            _indexedDB = indexedDB;
        }

        public void Step(in float deltaTime)
        {
            foreach (var result in _indexedDB.Select<MovableSet>().FromAll())
            {
                foreach (var i in result.indices)
                {
                    ref var position = ref result.set.position[i];
                    ref var velocity = ref result.set.velocity[i];

                    position.value += velocity.direction * velocity.speed * deltaTime;
                }
            }
        }
    }
}
