using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    internal class DamageFeedbackEngine : ITickEngine
    {
        private readonly IndexedDB _indexedDB;
        private readonly IEntityMemo<IGameObjectRow> _damagedEntities;

        public string name => nameof(DamageFeedbackEngine);

        public DamageFeedbackEngine(IndexedDB indexedDB, IEntityMemo<IGameObjectRow> damagedEntities)
        {
            _indexedDB = indexedDB;
            _damagedEntities = damagedEntities;
        }

        public void Step(in float deltaTime)
        {
            foreach (var result in _indexedDB
                .Select<DamageFeedbackSet>().FromAll<IGameObjectRow>().Where(_damagedEntities))
            {
                foreach (var i in result.indices)
                {
                    result.set.tint[i].value = Color.red;
                }
            }
        }
    }
}
