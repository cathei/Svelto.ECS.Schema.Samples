using Svelto.ECS.Schema.Internal;
using Svelto.ECS.Schema.Definition;
using Svelto.DataStructures;

namespace Svelto.ECS.Schema.Internal
{
    public readonly struct EntityIDQuery : IIndexQuery<IEntityRow>
    {
        internal readonly uint _entityID;

        internal EntityIDQuery(uint entityID)
        {
            _entityID = entityID;
        }

        void IIndexQuery.Apply(ResultSetQueryConfig config)
        {
            config.selectedEntityIDs.Add(_entityID);
        }
    }

    public readonly struct EntityIDMultiQuery : IIndexQuery<IEntityRow>
    {
        internal readonly uint[] _entityIDs;

        internal EntityIDMultiQuery(uint[] entityIDs)
        {
            _entityIDs = entityIDs;
        }

        void IIndexQuery.Apply(ResultSetQueryConfig config)
        {
            foreach (var entityID in _entityIDs)
                config.selectedEntityIDs.Add(entityID);
        }
    }
}

namespace Svelto.ECS.Schema
{
    public static class EntityID
    {
        public static EntityIDQuery Is(uint entityID) => new(entityID);
        public static EntityIDMultiQuery Is(params uint[] entityIDs) => new(entityIDs);
    }
}