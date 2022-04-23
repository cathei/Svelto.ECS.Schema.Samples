using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Internal;

namespace Cathei.Waaagh
{
    public struct PhysicsSyncSet : IResultSet<GameObjectComponent, PositionComponent>
    {
        public NB<GameObjectComponent> gameObject;
        public NB<PositionComponent> position;

        public void Init(in EntityCollection<GameObjectComponent, PositionComponent> buffers)
        {
            (gameObject, position, _) = buffers;
        }
    }

    public interface IPhysicsRow :
        IQueryableRow<PhysicsSyncSet>
    { }
}
