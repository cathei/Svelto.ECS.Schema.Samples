using System;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct PositionComponent : IEntityComponent
    {
        public Vector3 value;

        public PositionComponent(Vector3 value)
        {
            this.value = value;
        }
    }
}
