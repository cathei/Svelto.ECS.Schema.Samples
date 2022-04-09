using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct CanTargetSet : IResultSet<PositionComponent, VelocityComponent>
    {
        public NB<PositionComponent> position;
        public NB<VelocityComponent> velocity;

        public void Init(in EntityCollection<PositionComponent, VelocityComponent> buffers)
            => (position, velocity, _) = buffers;
    }

    public interface ICanTargetRow :
        IForeignKeyRow<TargetComponent>, IQueryableRow<CanTargetSet>
    { }
}
