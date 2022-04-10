using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    internal class TargetAimingEngine : IStepEngine<float>
    {
        private readonly IndexedDB _indexedDB;
        private readonly IForeignKey<TargetComponent, ITargetableRow> _targeted;

        public string name => nameof(TargetAimingEngine);

        public TargetAimingEngine(IndexedDB indexedDB, IForeignKey<TargetComponent, ITargetableRow> targeted)
        {
            _indexedDB = indexedDB;
            _targeted = targeted;
        }

        public void Step(in float deltaTime)
        {
            foreach (var result in _indexedDB.Select<CanTargetSet>().FromAll<ICanTargetRow>()
                                            .Join<TargetableSet>().On(_targeted))
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
