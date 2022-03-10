using System;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct TintComponent : IEntityComponent
    {
        public Color value;

        public TintComponent(Color value)
        {
            this.value = value;
        }
    }
}
