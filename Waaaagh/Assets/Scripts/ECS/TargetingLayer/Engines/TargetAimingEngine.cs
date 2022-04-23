using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    internal class TargetAimingEngine : ITickEngine
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
            foreach (var result in _indexedDB.Select<TargeterSet>().FromAll<ITargeterRow>()
                                            .Join<TargetableSet>().On(_targeted))
            {
                foreach (var (ia, ib) in result.indices)
                {
                    ref var targeterPosition = ref result.setA.position[ia];
                    ref var targeterVelocity = ref result.setA.velocity[ia];
                    ref var targeterTarget = ref result.setA.target[ia];

                    ref var targetablePosition = ref result.setB.position[ib];

                    var positionDiff = targetablePosition.value - targeterPosition.value;
                    targeterVelocity.direction = positionDiff.normalized;
                    targeterVelocity.speed = 1f;
                    targeterTarget.cachedDistSqr = positionDiff.sqrMagnitude;
                }
            }
        }
    }
}
