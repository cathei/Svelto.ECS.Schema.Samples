using System;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct GameObjectComponent : IEntityComponent
    {
        public PrefabID prefabID;
        public uint instanceID;

        public GameObjectComponent(PrefabID prefabID) : this()
        {
            this.prefabID = prefabID;
        }
    }
}
