using System;
using System.Collections.Generic;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;

namespace Cathei.Waaagh
{
    public interface IDamagableGameObjectRow :
        IDamagableRow, IGameObjectRow, IPhysicsRow
    { }

    public interface ICharacterRow :
        IDamagableGameObjectRow, IMovableRow, ICanAttackRow, IBurnableRow
    { }

    public interface IProjectileRow :
        IGameObjectRow, ICanAttackRow
    { }

    public interface IBuildingRow :
        IDamagableGameObjectRow, IBurnableRow
    { }

    public interface IOrcsSpawnRow :
        IBuildingRow, ISpawnableRow, IHealthRegenerableRow
    { }

    public sealed class OrcsRow : DescriptorRow<OrcsRow>, ICharacterRow { }
    public sealed class OrcsSpawnRow : DescriptorRow<OrcsSpawnRow>, IOrcsSpawnRow { }

    public sealed class HumanRow : DescriptorRow<HumanRow>, ICharacterRow { }
    public sealed class ArrowRow : DescriptorRow<ArrowRow>, IProjectileRow { }
}
