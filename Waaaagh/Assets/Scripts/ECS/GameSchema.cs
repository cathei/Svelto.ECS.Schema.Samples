using System;
using System.Collections.Generic;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;

namespace Cathei.Waaagh
{
    public interface ICharacterRow :
        IQueryableRow<MovementSet>,
        IQueryableRow<AttackableSet>,
        IQueryableRow<DefensibleSet>
    { }

    public interface IProjectileRow :
        IQueryableRow<AttackableSet>
    { }

    public interface IOrcSpawnRow :
        IQueryableRow<DefensibleSet>,
        IQueryableRow<OrcsSpawnSet>
    { }

    public class OrcsRow : DescriptorRow<OrcsRow>, ICharacterRow { }
    public class OrcsSpawnRow : DescriptorRow<OrcsSpawnRow>, IOrcSpawnRow { }

    public class HumanRow : DescriptorRow<HumanRow>, ICharacterRow { }
    public class ArrowRow : DescriptorRow<ArrowRow>, IProjectileRow { }

    public class GameSchema : IEntitySchema
    {
        public readonly Table<OrcsRow> Orcs = new();
        public readonly Table<OrcsSpawnRow> OrcsSpawn = new();

        public readonly Table<HumanRow> Human = new();
        public readonly Table<ArrowRow> Arrow = new();
    }
}
