using System;
using System.Collections.Generic;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct StatusBurnComponent : IIndexableComponent<bool>
    {
        public EGID ID { get; set; }
        public bool key { get => isBurning; set => isBurning = value; }

        public bool isBurning;
        public int burnDamage;

        public StatusBurnComponent(bool isBurning, int burnDamage) : this()
        {
            this.isBurning = isBurning;
            this.burnDamage = burnDamage;
        }
    }
}
