using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct MovableSet : IResultSet<PositionComponent, VelocityComponent>
    {
        public NB<PositionComponent> position;
        public NB<VelocityComponent> velocity;

        public int count { get; set; }

        public void Init(in EntityCollection<PositionComponent, VelocityComponent> buffers)
        {
            (position, velocity, count) = buffers;
        }
    }

    public interface ICanMove : IQueryableRow<MovableSet> { }
}
