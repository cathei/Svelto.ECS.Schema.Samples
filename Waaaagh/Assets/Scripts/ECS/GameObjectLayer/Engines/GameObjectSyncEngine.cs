using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public class GameObjectSyncEngine : IStepEngine<float>
    {
        private readonly IndexedDB _indexedDB;
        private readonly GameObjectResourceManager _goManager;

        public string name => nameof(GameObjectSyncEngine);

        public GameObjectSyncEngine(IndexedDB indexedDB, GameObjectResourceManager goManager)
        {
            _indexedDB = indexedDB;
            _goManager = goManager;
        }

        public void Step(in float deltaTime)
        {
            foreach (var result in _indexedDB.Select<GameObjectSet>().FromAll())
            {
                foreach (var i in result.indices)
                {
                    ref var instance = ref result.set.instance[i];
                    ref var position = ref result.set.position[i];
                    ref var tint = ref result.set.tint[i];

                    var bridge = _goManager.Get(instance.instanceID);
                    bridge.transform.position = position.value;
                    bridge.sprite.color = tint.value;

                    tint.value = Color.Lerp(tint.value, bridge.originalColor, deltaTime);
                }
            }
        }
    }
}
