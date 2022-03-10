using System;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct GameObjectComponent : IEntityComponent
    {
        public int prefabID;
        public int instanceID;
    }
}
