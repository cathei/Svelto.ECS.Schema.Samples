using System;
using System.Collections.Generic;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;

namespace Cathei.Waaagh
{
    public interface IDamagableGameObjectRow : IDamagableRow, IGameObjectRow { }

    public interface ICharacterRow :
        IMovableRow, ICanAttackRow, IDamagableRow, IBurnableRow
    { }

    public interface IProjectileRow :
        ICanAttackRow
    { }

    public interface IBuildingRow :
        IDamagableRow, IBurnableRow
    { }

    public interface IOrcsSpawnRow :
        IBuildingRow, ISpawnableRow, IHealthRegenerableRow
    { }

    public sealed class OrcsRow : DescriptorRow<OrcsRow>, IGameObjectRow, ICharacterRow { }
    public sealed class OrcsSpawnRow : DescriptorRow<OrcsSpawnRow>, IGameObjectRow, IOrcsSpawnRow { }

    public sealed class HumanRow : DescriptorRow<HumanRow>, IGameObjectRow, ICharacterRow { }
    public sealed class ArrowRow : DescriptorRow<ArrowRow>, IGameObjectRow, IProjectileRow { }
}
