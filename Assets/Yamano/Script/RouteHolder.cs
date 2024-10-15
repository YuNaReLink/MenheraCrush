using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    [Serializable]
    public struct Keyframe2D
    {
        public float time;
        public Vector2 position;
    }

    [Serializable]
    public struct RouteHolder
    {
        [SerializeField]
        private Keyframe2D[] keys;
        public readonly Vector2 GetPosition(float time)
        {
            if (keys.Length <= 0)
            {
                return Vector2.zero;
            }
            if (time <= keys[0].time)
            {
                return keys[0].position;
            }
            for (int i = 0; i < keys.Length - 1; i++)
            {
                if (time > keys[i + 1].time)
                {
                    continue;
                }
                float ratio = (time - keys[i].time) / (keys[i + 1].time - keys[i].time);
                Vector2 v = keys[i].position + (keys[i + 1].position - keys[i].position) * ratio;
                return v;
            }
            return keys[^1].position;
        }
    }
}
