using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    public class Automatton : MonoBehaviour
    {
        [SerializeField]
        float radius = 1.0f;
        float radian = 0.0f;
        [SerializeField]
        float radianSpeed = 1.0f;


        private void Update()
        {
            radian += radianSpeed * Time.deltaTime;

            Vector2 v = Vector2.one * radius;
            v.x *= Mathf.Cos(radian);
            v.y *= Mathf.Sin(radian);

            transform.position = v;
        }
    }
}

