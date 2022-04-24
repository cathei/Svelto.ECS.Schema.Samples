using System;
using System.Collections.Generic;
using System.Linq;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Schema.Definition;
using Svelto.ObjectPool;
using UnityEngine;

namespace Cathei.Waaagh
{
    public class EcsBridgeComponent : MonoBehaviour
    {
        public SpriteRenderer sprite;
        public Color originalColor;
        // public int instanceID;

        public TeamID teamID;
        public EntityReference selfReference;
        public HashSet<EntityReference> contacted = new();

        public void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
            originalColor = sprite.color;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            var otherBridge = other.GetComponent<EcsBridgeComponent>();
            if (otherBridge != null)
                contacted.Add(otherBridge.selfReference);
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            var otherBridge = other.GetComponent<EcsBridgeComponent>();
            if (otherBridge != null)
                contacted.Remove(otherBridge.selfReference);
        }
    }
}
