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
    public static class GameObjectLayerComposition
    {
        public static void Compose(Action<IEngine> addEngine, IndexedDB indexedDB,
            GameObjectManager goManager, IEntityMemo<IGameObjectRow> damaged)
        {
            addEngine(new DamageFeedbackEngine(indexedDB, damaged));
            addEngine(new GameObjectSpawnEngine(indexedDB, goManager));
            addEngine(new GameObjectSyncEngine(indexedDB, goManager));
        }
    }
}
