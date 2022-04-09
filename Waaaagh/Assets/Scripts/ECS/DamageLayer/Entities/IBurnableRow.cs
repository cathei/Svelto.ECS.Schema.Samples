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

        public void Init(in EntityCollection<HealthComponent, StatusBurnComponent> buffers)
        {
            (health, status, _) = buffers;
        }
    }

    public interface IBurnableRow :
        IIndexableRow<StatusBurnComponent>,
        IQueryableRow<BurnableSet>
    { }
}
