using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Internal;

namespace Cathei.Waaagh
{
    internal class PhysicsSyncEngine : ITickEngine
    {
        private readonly IndexedDB _indexedDB;
        private readonly GameObjectManager _goManager;

        public string name => nameof(PhysicsSyncEngine);

        public PhysicsSyncEngine(IndexedDB indexedDB, GameObjectManager goManager)
        {
            _indexedDB = indexedDB;
            _goManager = goManager;
        }

        public void Step(in float deltaTime)
        {
            foreach (var result in _indexedDB.Select<PhysicsSyncSet>().FromAll())
            {
                foreach (var i in result.indices)
                {
                    ref var go = ref result.set.gameObject[i];
                    ref var position = ref result.set.position[i];
                    ref var colliding = ref result.set.colliding[i];

                    var bridge = _goManager.Get(go.instanceID);
                    position.value = bridge.transform.position;

                    // we pick the first entity as contacting entity
                    // if for many-to-many relationship we need to define new entity
                    foreach (var other in bridge.contacted)
                    {
                        _indexedDB.Update(ref colliding, result.egid[i], other);
                        break;
                    }
                }
            }
        }
    }
}
