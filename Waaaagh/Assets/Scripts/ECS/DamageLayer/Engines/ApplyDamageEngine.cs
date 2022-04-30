using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    internal class ApplyDamageEngine : ITickEngine
    {
        private readonly IndexedDB _indexedDB;
        private readonly GameObjectManager _goManager;

        private readonly IForeignKey<CollidingComponent, IDamagableRow> _colliding;
        private readonly IEntityMemo<IDamagableRow> _damagedEntities;

        public string name => nameof(ApplyDamageEngine);

        public ApplyDamageEngine(IndexedDB indexedDB, GameObjectManager goManager,
            IForeignKey<CollidingComponent, IDamagableRow> colliding, IEntityMemo<IDamagableRow> damagedEntities)
        {
            _indexedDB = indexedDB;
            _goManager = goManager;
            _colliding = colliding;
            _damagedEntities = damagedEntities;
        }

        public void Step(in float deltaTime)
        {
            foreach (var result in _indexedDB.Select<DamagerSet>().FromAll<IDamagerRow>()
                                            .Join<DamagableSet>().On(_colliding))
            {
                foreach (var (ia, ib) in result.indices)
                {
                    ref var damagerDamage = ref result.setA.damage[ia];
                    ref var damagableHealth = ref result.setB.health[ib];
                    ref var damagableDefense = ref result.setB.defense[ib];

                    // already dead
                    if (damagableHealth.current <= 0)
                        continue;

                    damagableHealth.current -= Mathf.Max(0, damagerDamage.value - damagableDefense.value);

                    if (damagableHealth.current <= 0)
                        _indexedDB.Remove(result.egidB[ib]);

                    _indexedDB.Memo(_damagedEntities).Add(result.egidB[ib]);
                }
            }
        }
    }
}
