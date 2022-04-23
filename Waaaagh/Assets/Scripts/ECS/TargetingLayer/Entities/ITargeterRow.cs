using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct TargeterSet : IResultSet<TeamComponent, TargetComponent, PositionComponent, VelocityComponent>
    {
        public NB<TeamComponent> team;
        public NB<TargetComponent> target;
        public NB<PositionComponent> position;
        public NB<VelocityComponent> velocity;

        public void Init(in EntityCollection<TeamComponent, TargetComponent, PositionComponent, VelocityComponent> buffers)
            => (team, target, position, velocity, _) = buffers;
    }

    public interface ITargeterRow :
        IForeignKeyRow<TargetComponent>, IQueryableRow<TargeterSet>
    { }
}
