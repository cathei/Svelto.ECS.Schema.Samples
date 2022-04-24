using System;
using System.Collections.Generic;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct TeamComponent : IEntityComponent
    {
        public TeamID team;

        public TeamComponent(TeamID team)
        {
            this.team = team;
        }
    }
}
