using System;
using System.Collections.Generic;
using Svelto.Context;
using Svelto.ECS;
using Svelto.ECS.Schedulers;
using Svelto.ECS.Schema.Definition;
using UnityEngine;

namespace Cathei.Waaagh
{
    public static class Constants
    {
        public enum PrefabID : uint
        {
            Guardman = 0,
            Archer = 1,
            Mage = 2,

            Orcs = 100,
            OrcsSpawn = 101,

            Arrow = 200,
            Fireball = 201,

            HpBar = 500
        }
    }
}
