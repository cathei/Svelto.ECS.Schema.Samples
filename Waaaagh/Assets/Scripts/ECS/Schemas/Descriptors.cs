using System;
using System.Collections.Generic;
using Svelto.ECS.Schema;
using Svelto.ECS.Schema.Definition;

namespace Cathei.Waaagh
{
    public interface IDamagableRow :
        IMemorableRow, ICanBeBurned, ICanBeDamaged
    { }

    public interface ICharacterRow :
        ICanMove, ICanAttack, IDamagableRow
    { }

    public interface IProjectileRow :
        ICanAttack
    { }

    public interface IBuildingRow :
        IDamagableRow
    { }

    public interface IOrcsSpawnRow :
        IBuildingRow, ICanSpawn, ICanRegenHealth
    { }

    public sealed class OrcsRow : DescriptorRow<OrcsRow>, IHaveGameObject, ICharacterRow { }
    public sealed class OrcsSpawnRow : DescriptorRow<OrcsSpawnRow>, IHaveGameObject, IOrcsSpawnRow { }

    public sealed class HumanRow : DescriptorRow<HumanRow>, IHaveGameObject, ICharacterRow { }
    public sealed class ArrowRow : DescriptorRow<ArrowRow>, IHaveGameObject, IProjectileRow { }
}
