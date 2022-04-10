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

        private readonly Dictionary<PrefabID, GameObject> _prefabs;
        private readonly FasterDictionary<uint, EcsBridgeComponent> _idToInstances = new();

        private uint _nextInstanceID;

        public GameObjectResourceManager(DesignsDB designsDB)
        {
            _prefabs = designsDB.prefabInfos.ToDictionary(x => x.prefabID, x => x.prefab);

            _rootActive = new GameObject("Root");
            _rootInactive = new GameObject("Inactive");
            _rootInactive.SetActive(false);

            _pool = new GameObjectPool();
        }

        public uint Create(PrefabID prefabID)
        {
            uint id = _nextInstanceID++;

            var go = _pool.Use((int)prefabID, SpawnNewGameObject(prefabID));

            go.transform.SetParent(_rootActive.transform);

            _idToInstances[id] = go.GetComponent<EcsBridgeComponent>();
            return id;
        }

        private Func<GameObject> SpawnNewGameObject(PrefabID prefabID)
        {
            return () => {
                var go = GameObject.Instantiate(_prefabs[prefabID]);
                go.AddComponent<EcsBridgeComponent>();
                return go;
            };
        }

        public EcsBridgeComponent Get(uint instanceID)
        {
            return _idToInstances[instanceID];
        }

        public void Return(PrefabID prefabID, uint instanceID)
        {
            var bridge = _idToInstances[instanceID];

            _pool.Recycle(bridge.gameObject, (int)prefabID);

            bridge.transform.SetParent(_rootInactive.transform);

            _idToInstances.Remove(instanceID);
        }

        public void Dispose()
        {
            _pool.Dispose();

            GameObject.Destroy(_rootActive);
            GameObject.Destroy(_rootInactive);
        }
    }
}
