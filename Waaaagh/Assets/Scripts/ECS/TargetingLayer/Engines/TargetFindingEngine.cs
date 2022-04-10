using System;
using System.Collections.Generic;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema;
using UnityEngine;

namespace Cathei.Waaagh
{
    internal class TargetFindingEngine : IStepEngine<float>
    {
        private readonly IndexedDB _indexedDB;

        public string name => nameof(TargetFindingEngine);

        public TargetFindingEngine(IndexedDB indexedDB)
        {
            _indexedDB = indexedDB;
        }

        public void Step(in float deltaTime)
        {

        }
    }
}
