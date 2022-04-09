using System;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct HealthComponent : IEntityComponent
    {
        public int current;
        public int max;

        public HealthComponent(int max)
        {
            this.current = this.max = max;
        }
    }
}
