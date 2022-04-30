using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Internal;

namespace Cathei.Waaagh
{
    public struct PhysicsSyncSet : IResultSet<GameObjectComponent, PositionComponent, CollidingComponent>
    {
        public NB<GameObjectComponent> gameObject;
        public NB<PositionComponent> position;
        public NB<CollidingComponent> colliding;

        public void Init(in EntityCollection<GameObjectComponent, PositionComponent, CollidingComponent> buffers)
        {
            (gameObject, position, colliding, _) = buffers;
        }
    }

    public interface IPhysicsRow :
        IQueryableRow<PhysicsSyncSet>
    { }
}
