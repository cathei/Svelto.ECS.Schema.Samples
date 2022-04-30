using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct DamagerSet : IResultSet<DamageComponent>
    {
        public NB<DamageComponent> damage;

        public void Init(in EntityCollection<DamageComponent> buffers)
        {
            (damage, _) = buffers;
        }
    }

    public interface IDamagerRow :
        IQueryableRow<DamagerSet>,
        IForeignKeyRow<CollidingComponent>
    { }
}
