using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct CanAttackSet : IResultSet<DamageComponent>
    {
        public NB<DamageComponent> damage;

        public void Init(in EntityCollection<DamageComponent> buffers)
        {
            (damage, _) = buffers;
        }
    }

    public interface ICanAttackRow : IQueryableRow<CanAttackSet> { }
}
