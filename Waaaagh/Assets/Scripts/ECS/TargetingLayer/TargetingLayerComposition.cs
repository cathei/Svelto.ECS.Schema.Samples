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
    public static class TargetingLayerComposition
    {
        public static void Compose(Action<IEngine> addEngine, IndexedDB indexedDB, IForeignKey<TargetComponent, ITargetableRow> targeted)
        {
            addEngine(new TargetFindingEngine(indexedDB));
            addEngine(new TargetAimingEngine(indexedDB, targeted));
        }
    }
}
