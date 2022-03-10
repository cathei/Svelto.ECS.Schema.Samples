using System;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct TargetComponent : IEntityComponent
    {
        public EntityReference value;
    }
}
