using System;
using System.Collections.Generic;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    public struct ClassComponent : IKeyComponent<EnumKey<ClassID>>
    {
        public EnumKey<ClassID> key { get; set; }

        public ClassComponent(ClassID classID) => key = classID;
    }
}
