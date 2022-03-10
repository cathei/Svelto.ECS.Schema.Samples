using System;
using System.Collections.Generic;
using Svelto.Context;
using Svelto.ECS;
using Svelto.ECS.Schedulers;
using Svelto.ECS.Schema.Definition;
using UnityEngine;

namespace Cathei.Waaagh
{
    [CreateAssetMenu(fileName = "DesignsDB", menuName = "ScriptableObjects/DesignsDB", order = 1)]
    public class DesignsDB : ScriptableObject
    {
        [Serializable]
        public class PrefabInfo
        {
            public Constants.PrefabID prefabID;
            public GameObject prefab;
        }

        public List<PrefabInfo> prefabInfos;
    }
}
