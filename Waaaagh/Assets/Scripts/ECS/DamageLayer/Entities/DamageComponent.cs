using System;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct DamageComponent : IEntityComponent
    {
        public int value;

        public DamageComponent(int value)
        {
            this.value = value;
        }
    }
}
