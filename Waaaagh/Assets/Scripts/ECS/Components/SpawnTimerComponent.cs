using System;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct SpawnTimerComponent : IEntityComponent
    {
        public float current;
        public float nextSpawn;

        public SpawnTimerComponent(float nextSpawn)
        {
            this.current = 0;
            this.nextSpawn = nextSpawn;
        }
    }
}
