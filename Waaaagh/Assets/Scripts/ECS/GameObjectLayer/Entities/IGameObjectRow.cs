using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct GameObjectInitSet : IResultSet<PositionComponent, TintComponent>
    {
        public NB<PositionComponent> position;
        public NB<TintComponent> tint;

        public void Init(in EntityCollection<PositionComponent, TintComponent> buffers)
        {
            (position, tint, _) = buffers;
        }
    }

    public struct GameObjectSet : IResultSet<PositionComponent, GameObjectComponent, TintComponent>
    {
        public NB<PositionComponent> position;
        public NB<GameObjectComponent> instance;
        public NB<TintComponent> tint;

        public void Init(in EntityCollection<PositionComponent, GameObjectComponent, TintComponent> buffers)
        {
            (position, instance, tint, _) = buffers;
        }
    }

    public struct DamageFeedbackSet : IResultSet<TintComponent>
    {
        public NB<TintComponent> tint;

        public void Init(in EntityCollection<TintComponent> buffers)
        {
            (tint, _) = buffers;
        }
    }

    public interface IGameObjectRow :
        IQueryableRow<GameObjectInitSet>,
        IQueryableRow<GameObjectSet>,
        IReactiveRow<GameObjectComponent>,
        IQueryableRow<DamageFeedbackSet>
    { }
}
