using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Internal;

namespace Cathei.Waaagh
{
    internal class GameObjectSpawnEngine :
        IReactRowAdd<IGameObjectRow, GameObjectComponent>,
        IReactRowRemove<IGameObjectRow, GameObjectComponent>
    {
        private readonly GameObjectManager _goManager;

        public GameObjectSpawnEngine(IndexedDB indexedDB, GameObjectManager goManager)
        {
            this.indexedDB = indexedDB;
            _goManager = goManager;
        }

        public IndexedDB indexedDB { get; }

        public void Add(in EntityCollection<GameObjectComponent> collection, RangedIndices indices, ExclusiveGroupStruct group)
        {
            var (instance, _) = collection;
            var initSet = indexedDB.Select<GameObjectInitSet>().From(group);

            foreach (var i in indices)
            {
                var bridge = _goManager.Create(ref instance[i]);
                bridge.transform.position = initSet.position[i].value;
                initSet.tint[i].value = bridge.originalColor;
            }
        }

        public void Remove(in EntityCollection<GameObjectComponent> collection, RangedIndices indices, ExclusiveGroupStruct group)
        {
            var (instance, _) = collection;

            foreach (var i in indices)
                _goManager.Return(ref instance[i]);
        }
    }
}
