using System;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct GameObjectComponent : IEntityComponent
    {
        public Constants.PrefabID prefabID;
        public uint instanceID;

        public GameObjectComponent(Constants.PrefabID prefabID, uint instanceID)
        {
            this.prefabID = prefabID;
            this.instanceID = instanceID;
        }
    }
}
