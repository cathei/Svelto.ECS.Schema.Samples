using System;
using System.Collections.Generic;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct CollidingComponent : IForeignKeyComponent
    {
        public EntityReference reference { get; set; }
    }
}
