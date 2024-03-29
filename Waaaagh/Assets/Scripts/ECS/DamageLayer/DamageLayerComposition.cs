using System;
using System.Collections.Generic;
using Svelto.Context;
using Svelto.ECS;
using Svelto.ECS.Schedulers;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;
using UnityEngine;

namespace Cathei.Waaagh
{
    public static class DamageLayerComposition
    {
        public static void Compose(Action<IEngine> addEngine, IndexedDB indexedDB,
            GameObjectManager goManager, IForeignKey<CollidingComponent, IDamagableRow> colliding,
            IEntityMemo<IDamagableRow> damaged)
        {
            addEngine(new ApplyDamageEngine(indexedDB, goManager, colliding, damaged));
        }
    }
}
