using System;
using System.Collections.Generic;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct TargetComponent : IForeignKeyComponent
    {
        public EntityReference reference { get; set; }
        public float cachedDistSqr;
    }
}
