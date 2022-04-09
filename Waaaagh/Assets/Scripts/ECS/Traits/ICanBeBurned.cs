using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct BurnableSet : IResultSet<HealthComponent, StatusBurnComponent>
    {
        public NB<HealthComponent> health;
        public NB<StatusBurnComponent> status;

        public int count { get; set; }

        public void Init(in EntityCollection<HealthComponent, StatusBurnComponent> buffers)
        {
            (health, status, count) = buffers;
        }
    }

    public interface ICanBeBurned :
        IIndexableRow<StatusBurnComponent>,
        IQueryableRow<BurnableSet>
    { }
}
