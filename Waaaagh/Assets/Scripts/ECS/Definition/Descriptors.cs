using System;
using System.Collections.Generic;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;

namespace Cathei.Waaagh
{
    public interface IDamagableRow :
        IQueryableRow<DefensibleSet>,
        IMemorableRow
    { }

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

    public interface IGameObjectRow :
        IQueryableRow<GameObjectSet>,
        IReactiveRow<GameObjectComponent>
    { }

    public sealed class OrcsRow : DescriptorRow<OrcsRow>, IGameObjectRow, ICharacterRow { }
    public sealed class OrcsSpawnRow : DescriptorRow<OrcsSpawnRow>, IGameObjectRow, IOrcSpawnRow { }

    public sealed class HumanRow : DescriptorRow<HumanRow>, IGameObjectRow, ICharacterRow { }
    public sealed class ArrowRow : DescriptorRow<ArrowRow>, IGameObjectRow, IProjectileRow { }
}
