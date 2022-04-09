using System;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct VelocityComponent : IEntityComponent
    {
        public Vector3 value;
    }
}
