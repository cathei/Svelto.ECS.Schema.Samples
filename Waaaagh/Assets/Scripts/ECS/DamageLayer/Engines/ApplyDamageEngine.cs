using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;

namespace Cathei.Waaagh
{
    internal class ApplyDamageEngine : IStepEngine<float>
    {
        private readonly IndexedDB _indexedDB;

        private readonly IEntityMemo<IDamagableRow> _damagedEntities;

        public string name => nameof(ApplyDamageEngine);

        public ApplyDamageEngine(IndexedDB indexedDB, IEntityMemo<IDamagableRow> damagedEntities)
        {
            _indexedDB = indexedDB;
            _damagedEntities = damagedEntities;
        }

        public void Step(in float deltaTime)
        {

        }
    }
}
