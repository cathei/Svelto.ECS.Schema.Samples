using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public class TargetFindingEngine : IStepEngine<float>
    {
        private readonly IndexedDB _indexedDB;
        private readonly ITargetSchema _schema;

        public string name => nameof(TargetFindingEngine);

        public TargetFindingEngine(IndexedDB indexedDB, ITargetSchema schema)
        {
            _indexedDB = indexedDB;
            _schema = schema;
        }

        public void Step(in float deltaTime)
        {
            foreach (var result in _indexedDB.Select<CanTargetSet>().FromAll<ICanTargetRow>()
                                            .Join<TargetableSet>().On(_schema.Targeted))
            {
                foreach (var (ia, ib) in result.indices)
                {
                    var positionDiff = result.setB.position[ib].value - result.setA.position[ia].value;
                    result.setA.velocity[ia].direction = positionDiff.normalized;
                }
            }
        }
    }
}
