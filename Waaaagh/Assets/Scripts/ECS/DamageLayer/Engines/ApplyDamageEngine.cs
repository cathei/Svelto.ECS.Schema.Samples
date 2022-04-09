using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    public class ApplyDamageEngine : IStepEngine<float>
    {
        private readonly IndexedDB _indexedDB;

        public string name => nameof(ApplyDamageEngine);

        public ApplyDamageEngine(IndexedDB indexedDB)
        {
            _indexedDB = indexedDB;
        }

        public void Step(in float deltaTime)
        {

        }
    }
}
