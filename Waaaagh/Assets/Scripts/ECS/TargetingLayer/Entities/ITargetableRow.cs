using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct TargetableSet : IResultSet<PositionComponent>
    {
        public NB<PositionComponent> position;

        public void Init(in EntityCollection<PositionComponent> buffers)
            => (position, _) = buffers;
    }

    public interface ITargetableRow :
        IReferenceableRow<TargetComponent>, IQueryableRow<TargetableSet>
    { }
}
