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

        public readonly Table<HumanRow> Guardman = new();
        public readonly Table<HumanRow> Archer = new();
        public readonly Table<HumanRow> Mage = new();

        public readonly Table<ArrowRow> Arrow = new();

        public readonly Index<StatusBurnComponent> StatusBurn = new();

        public readonly ForeignKey<TargetComponent, ITargetableRow> Targeted = new();

        public readonly Memo<IDamagableGameObjectRow> Damaged = new();
    }
}
