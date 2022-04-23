using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cathei.Waaagh
{
    [CreateAssetMenu(fileName = "DesignsDB", menuName = "ScriptableObjects/DesignsDB", order = 1)]
    public class DesignsDB : ScriptableObject
    {
        [Serializable]
        public class PrefabInfo
        {
            public PrefabID prefabID;
            public GameObject prefab;
        }

        public float MapWidth;
        public float MapHeight;

        public List<PrefabInfo> prefabInfos;
    }
}
