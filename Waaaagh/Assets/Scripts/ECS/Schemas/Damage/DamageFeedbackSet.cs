using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public struct DamageFeedbackSet : IResultSet<TintComponent>
    {
        public NB<TintComponent> tint;

        public int count { get; set; }

        public void Init(in EntityCollection<TintComponent> buffers)
        {
            (tint, count) = buffers;
        }
    }
}
