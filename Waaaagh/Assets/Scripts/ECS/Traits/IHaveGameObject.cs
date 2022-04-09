using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct GameObjectSet : IResultSet<PositionComponent, GameObjectComponent, TintComponent>
    {
        public NB<PositionComponent> position;
        public NB<GameObjectComponent> instance;
        public NB<TintComponent> tint;

        public int count { get; set; }

        public void Init(in EntityCollection<PositionComponent, GameObjectComponent, TintComponent> buffers)
        {
            (position, instance, tint, count) = buffers;
        }
    }

    public interface IHaveGameObject :
        IQueryableRow<GameObjectSet>,
        IReactiveRow<GameObjectComponent>
    { }
}
