using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public class GameObjectSpawnEngine : ReactToRowEngine<IGameObjectRow, GameObjectComponent>
    {
        private readonly GameSchema _schema;
        private readonly IEntityFactory _factory;
        private readonly GameObjectResourceManager _goManager;

        public string name => nameof(GameObjectSpawnEngine);

        public GameObjectSpawnEngine(IndexedDB indexedDB, GameSchema schema, IEntityFactory factory,
            GameObjectResourceManager goManager) : base(indexedDB)
        {
            _schema = schema;
            _factory = factory;
            _goManager = goManager;
        }

        protected override void Add(ref GameObjectComponent instance, IEntityTable<IGameObjectRow> table, uint entityID)
        {
            instance.instanceID = _goManager.Create(instance.prefabID);
        }

        protected override void Remove(ref GameObjectComponent instance, IEntityTable<IGameObjectRow> table, uint entityID)
        {
            _goManager.Return(instance.prefabID, instance.instanceID);
        }
    }
}
