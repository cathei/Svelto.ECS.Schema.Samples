using System;
using System.Collections.Generic;
using Svelto.ECS.Schema.Definition;
using Svelto.ObjectPool;

namespace Cathei.Waaagh
{
    public class GameObjectResourceManager
    {
        private readonly GameObjectPool _pool;

        public GameObjectResourceManager()
        {
            _pool = new GameObjectPool();
        }

    }
}
