using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct TargetableSet : IResultSet<TeamComponent, PositionComponent>
    {
        public NB<TeamComponent> team;
        public NB<PositionComponent> position;

        public void Init(in EntityCollection<TeamComponent, PositionComponent> buffers)
            => (team, position, _) = buffers;
    }

    public interface ITargetableRow :
        IReferenceableRow<TargetComponent>, IQueryableRow<TargetableSet>
    { }
}
