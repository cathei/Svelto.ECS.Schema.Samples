using System;
using System.Collections.Generic;
using System.Linq;
using Svelto.DataStructures;
using Svelto.ECS.Schema.Definition;
using Svelto.ObjectPool;
using UnityEngine;

namespace Cathei.Waaagh
{
    public class GameObjectResourceManager : IDisposable
    {
        private readonly GameObjectPool _pool;

        private readonly GameObject _rootActive;
        private readonly GameObject _rootInactive;

        private readonly Dictionary<Constants.PrefabID, GameObject> _prefabs;
        private readonly FasterDictionary<uint, GameObject> _idToObjects = new FasterDictionary<uint, GameObject>();

        private uint _nextInstanceID;

        public GameObjectResourceManager(DesignsDB designsDB)
        {
            _prefabs = designsDB.prefabInfos.ToDictionary(x => x.prefabID, x => x.prefab);

            _rootActive = new GameObject("Root");
            _rootInactive = new GameObject("Inactive");
            _rootInactive.SetActive(false);

            _pool = new GameObjectPool();
        }

        public uint Create(Constants.PrefabID prefabID)
        {
            uint id = _nextInstanceID++;

            var go = _pool.Use((int)prefabID, () =>
                GameObject.Instantiate(_prefabs[prefabID]));

            go.transform.SetParent(_rootActive.transform);

            _idToObjects[id] = go;
            return id;
        }

        public GameObject Get(uint instanceID)
        {
            return _idToObjects[instanceID];
        }

        public void Return(Constants.PrefabID prefabID, uint instanceID)
        {
            var go = _idToObjects[instanceID];

            _pool.Recycle(go, (int)prefabID);

            go.transform.SetParent(_rootInactive.transform);

            _idToObjects.Remove(instanceID);
        }

        public void Dispose()
        {
            _pool.Dispose();

            GameObject.Destroy(_rootActive);
            GameObject.Destroy(_rootInactive);
        }
    }
}
