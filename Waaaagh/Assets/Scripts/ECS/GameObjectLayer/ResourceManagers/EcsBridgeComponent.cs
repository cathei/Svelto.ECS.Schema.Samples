using System;
using System.Collections.Generic;
using System.Linq;
using Svelto.DataStructures;
using Svelto.ECS.Schema.Definition;
using Svelto.ObjectPool;
using UnityEngine;

namespace Cathei.Waaagh
{
    public class EcsBridgeComponent : MonoBehaviour
    {
        public SpriteRenderer sprite;
        public Color originalColor;

        public void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
            originalColor = sprite.color;
        }
    }
}
