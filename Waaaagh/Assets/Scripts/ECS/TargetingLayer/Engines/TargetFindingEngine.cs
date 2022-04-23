using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    internal class TargetFindingEngine : ITickEngine
    {
        private readonly IndexedDB _indexedDB;

        public string name => nameof(TargetFindingEngine);

        public TargetFindingEngine(IndexedDB indexedDB)
        {
            _indexedDB = indexedDB;
        }

        public void Step(in float deltaTime)
        {
            // double iteration - can be much more optimized
            // but probably enough for example purpose
            foreach (var targeter in _indexedDB.Select<TargeterSet>().FromAll())
            foreach (var targetable in _indexedDB.Select<TargetableSet>().FromAll())
            {
                foreach (var ia in targeter.indices)
                {
                    ref var targeterTeam = ref targeter.set.team[ia];
                    ref var targeterTarget = ref targeter.set.target[ia];
                    ref var targeterPosition = ref targeter.set.position[ia];

                    EGID minEGID = default;
                    float minDistSqr = float.MaxValue;

                    if (_indexedDB.TryGetEGID(targeterTarget.reference, out var _))
                    {
                        // has a valid target
                        minDistSqr = targeterTarget.cachedDistSqr;
                    }

                    foreach (var ib in targetable.indices)
                    {
                        ref var targetableTeam = ref targetable.set.team[ib];
                        ref var targetablePosition = ref targetable.set.position[ib];

                        if (targeterTeam.team == targetableTeam.team)
                            continue;

                        var distSqr = (targeterPosition.value - targetablePosition.value).sqrMagnitude;

                        if (distSqr < minDistSqr)
                        {
                            minEGID = targetable.egid[ib];
                            minDistSqr = distSqr;
                        }
                    }

                    if (minEGID != default)
                    {
                        // assign new target
                        _indexedDB.Update(ref targeterTarget,
                            targeter.egid[ia], _indexedDB.GetEntityReference(minEGID));

                        targeterTarget.cachedDistSqr = minDistSqr;
                    }
                }
            }
        }
    }
}
