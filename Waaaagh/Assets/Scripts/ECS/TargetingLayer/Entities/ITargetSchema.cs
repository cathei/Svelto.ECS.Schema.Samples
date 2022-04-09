using System;
using System.Collections.Generic;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public interface ITargetSchema
    {
        public ForeignKey<TargetComponent, ITargetableRow> Targeted { get; }
    }
}
