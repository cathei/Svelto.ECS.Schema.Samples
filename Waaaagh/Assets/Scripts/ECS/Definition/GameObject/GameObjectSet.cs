using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct GameObjectSet : IResultSet<PositionComponent, GameObjectComponent>
    {
        public NB<PositionComponent> position;
        public NB<GameObjectComponent> instance;

        public int count { get; set; }

        public void Init(in EntityCollection<PositionComponent, GameObjectComponent> buffers)
        {
            (position, instance, count) = buffers;
        }
    }
}
