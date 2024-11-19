using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //テスト用の適当なコンポーネント
    //入力担当
    public class Tester : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D target = null;
        [SerializeField]
        private new SpriteRenderer renderer;
        private void Update()
        {
            float s = Mathf.Sin(Time.time * 1.5f);
            renderer.material.SetFloat("_Offset", s);
            float f = renderer.material.GetFloat("_Offset");
            if (Input.anyKeyDown)
            {
                target.AddForce(10 * Vector2.left);
            }
        }
    }
}

