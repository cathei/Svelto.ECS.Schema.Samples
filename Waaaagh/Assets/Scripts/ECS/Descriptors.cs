using System;
using System.Collections.Generic;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;

namespace Cathei.Waaagh
{
    public interface IUnitRow :
        IDamagableRow, IGameObjectRow, IPhysicsRow, ITargeterRow, ITargetableRow
    { }

    public interface IProjectileRow :
        IGameObjectRow, IPhysicsRow, ICanAttackRow
    { }

    public interface ICharacterRow :
        IUnitRow, IMovableRow, ICanAttackRow, IBurnableRow
    { }

    public interface IBuildingRow :
        IUnitRow, IBurnableRow
    { }

    public interface IOrcsSpawnRow :
        IBuildingRow, ISpawnableRow, IHealthRegenerableRow
    { }

    public sealed class OrcsRow : DescriptorRow<OrcsRow>, ICharacterRow { }
    public sealed class OrcsSpawnRow : DescriptorRow<OrcsSpawnRow>, IOrcsSpawnRow { }

    public sealed class HumanRow : DescriptorRow<HumanRow>, ICharacterRow, IPrimaryKeyRow<ClassComponent> { }
    public sealed class ArrowRow : DescriptorRow<ArrowRow>, IProjectileRow { }
}
