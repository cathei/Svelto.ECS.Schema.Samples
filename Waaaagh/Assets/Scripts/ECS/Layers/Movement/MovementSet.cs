using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct MovementSet : IResultSet<PositionComponent>
    {
        public NB<PositionComponent> position;

        public int count { get; set; }

        public void Init(in EntityCollection<PositionComponent> buffers)
        {
            (position, count) = buffers;
        }
    }
}
