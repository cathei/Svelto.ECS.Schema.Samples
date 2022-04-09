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

        public int count { get; set; }

        public void Init(in EntityCollection<HealthComponent, DefenseComponent> buffers)
        {
            (health, defense, count) = buffers;
        }
    }

    public struct DamageFeedbackSet : IResultSet<TintComponent>
    {
        public NB<TintComponent> tint;

        public int count { get; set; }

        public void Init(in EntityCollection<TintComponent> buffers)
        {
            (tint, count) = buffers;
        }
    }

    public interface IDamagableRow :
        IBurnableRow,
        IQueryableRow<DamagableSet>,
        IQueryableRow<DamageFeedbackSet>
    { }
}
