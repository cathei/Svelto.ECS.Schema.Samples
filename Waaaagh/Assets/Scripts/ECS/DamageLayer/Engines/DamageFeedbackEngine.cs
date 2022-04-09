using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public class DamageFeedbackEngine : IStepEngine<float>
    {
        private readonly IndexedDB _indexedDB;
        private readonly GameSchema _schema;

        public string name => nameof(DamageFeedbackEngine);

        public DamageFeedbackEngine(IndexedDB indexedDB, GameSchema schema)
        {
            _indexedDB = indexedDB;
            _schema = schema;
        }

        public void Step(in float deltaTime)
        {
            foreach (var result in _indexedDB
                .Select<DamageFeedbackSet>().FromAll<IDamagableRow>().Where(_schema.Damaged))
            {
                foreach (var i in result.indices)
                {
                    result.set.tint[i].value = Color.red;
                }
            }

            _indexedDB.Memo(_schema.Damaged).Clear();
        }
    }
}
