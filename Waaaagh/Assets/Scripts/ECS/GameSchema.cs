using System;
using System.Collections.Generic;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;
using UnityEngine;

namespace Cathei.Waaagh
{
    public class GameSchema : IEntitySchema
    {
        public readonly Table<HumanRow> Human = new();
        public readonly Table<ArrowRow> Arrow = new();

        public readonly Table<OrcsRow> Orcs = new();
        public readonly Table<OrcsSpawnRow> OrcsSpawn = new();

        public readonly Index<StatusBurnComponent> StatusBurn = new();

        public readonly PrimaryKey<ClassComponent> Class = new();

        public readonly ForeignKey<TargetComponent, ITargetableRow> Targeted = new();

        public readonly Memo<IUnitRow> Damaged = new();

        public GameSchema()
        {
            Human.SetDefault(new GameObjectComponent(PrefabID.Human));
            Human.SetDefault(new TeamComponent(TeamID.Human));

            Orcs.SetDefault(new GameObjectComponent(PrefabID.Orcs));
            Orcs.SetDefault(new TeamComponent(TeamID.Orcs));

            OrcsSpawn.SetDefault(new GameObjectComponent(PrefabID.OrcsSpawn));
            OrcsSpawn.SetDefault(new TeamComponent(TeamID.Orcs));

            Human.AddPrimaryKeys(Class);
            Class.SetPossibleKeys(ClassID.Guardman, ClassID.Archer, ClassID.Mage);
        }
    }
}
