using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct OrcsSpawnSet : IResultSet<SpawnTimerComponent>
    {
        public NB<SpawnTimerComponent> spawnTimer;

        public int count { get; set; }

        public void Init(in EntityCollection<SpawnTimerComponent> buffers)
        {
            (spawnTimer, count) = buffers;
        }
    }
}
