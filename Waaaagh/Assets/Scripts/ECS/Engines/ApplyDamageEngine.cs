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
        private readonly GameSchema _schema;

        public string name => nameof(ApplyDamageEngine);

        public ApplyDamageEngine(IndexedDB indexedDB, GameSchema schema)
        {
            _indexedDB = indexedDB;
            _schema = schema;
        }

        public void Step(in float deltaTime)
        {

        }
    }
}
