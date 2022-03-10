using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public class GameObjectSyncEngine : IStepEngine<float>
    {
        private readonly IndexedDB _indexedDB;
        private readonly GameSchema _schema;

        private readonly GameObjectResourceManager _goManager;

        public string name => nameof(GameObjectSyncEngine);

        public GameObjectSyncEngine(IndexedDB indexedDB, GameSchema schema, GameObjectResourceManager goManager)
        {
            _indexedDB = indexedDB;
            _schema = schema;
            _goManager = goManager;
        }

        public void Step(in float deltaTime)
        {

        }
    }
}