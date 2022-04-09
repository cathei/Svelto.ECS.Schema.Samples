using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct MovableSet : IResultSet<PositionComponent, VelocityComponent>
    {
        public NB<PositionComponent> position;
        public NB<VelocityComponent> velocity;

        public void Init(in EntityCollection<PositionComponent, VelocityComponent> buffers)
        {
            (position, velocity, _) = buffers;
        }

    }

    public interface IMovableRow : IQueryableRow<MovableSet>
    { }
}