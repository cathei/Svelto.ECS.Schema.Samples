using System;
using System.Collections.Generic;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;

namespace Cathei.Waaagh
{
    public interface IDamagableRow :
        IQueryableRow<DefensibleSet>,
        IMemorableRow

    public interface ICharacterRow :
        IDamagableRow,
        IQueryableRow<MovableSet>,
        IQueryableRow<AttackableSet>
    { }

    public interface IProjectileRow :
        IQueryableRow<AttackableSet>
    { }

    public interface IOrcSpawnRow :
        IDamagableRow,
        IQueryableRow<OrcsSpawnSet>,
        IQueryableRow<HealthRegenerableSet>
    { }

    public sealed class OrcsRow : DescriptorRow<OrcsRow>, ICharacterRow { }
    public sealed class OrcsSpawnRow : DescriptorRow<OrcsSpawnRow>, IOrcSpawnRow { }

    public sealed class HumanRow : DescriptorRow<HumanRow>, ICharacterRow { }
    public sealed class ArrowRow : DescriptorRow<ArrowRow>, IProjectileRow { }
}
