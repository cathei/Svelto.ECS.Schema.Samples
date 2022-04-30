using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct DamagableSet : IResultSet<HealthComponent, DefenseComponent>
    {
        public NB<HealthComponent> health;
        public NB<DefenseComponent> defense;

        public void Init(in EntityCollection<HealthComponent, DefenseComponent> buffers)
        {
            (health, defense, _) = buffers;
        }
    }

    public interface IDamagableRow :
        IQueryableRow<DamagableSet>,
        IReferenceableRow<CollidingComponent>
    { }
}
