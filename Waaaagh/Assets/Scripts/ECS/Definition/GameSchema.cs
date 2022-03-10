using System;
using System.Collections.Generic;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;

namespace Cathei.Waaagh
{
    public class GameSchema : IEntitySchema
    {
        public readonly Table<OrcsRow> Orcs = new();
        public readonly Table<OrcsSpawnRow> OrcsSpawn = new();

        public readonly Table<HumanRow> Human = new();
        public readonly Table<ArrowRow> Arrow = new();

        public readonly Memo<IDamagableRow> Damaged = new();
    }
}
