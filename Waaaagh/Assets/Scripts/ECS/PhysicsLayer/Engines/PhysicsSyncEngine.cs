using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Internal;

namespace Cathei.Waaagh
{
    internal class PhysicsSyncEngine : ITickEngine
    {
        private readonly IndexedDB _indexedDB;
        private readonly GameObjectResourceManager _goManager;

        public string name => nameof(PhysicsSyncEngine);

        public PhysicsSyncEngine(IndexedDB indexedDB, GameObjectResourceManager goManager)
        {
            _indexedDB = indexedDB;
            _goManager = goManager;
        }

        public IndexedDB indexedDB { get; }

        public void Step(in float deltaTime)
        {

        }

    }
}
