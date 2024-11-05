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
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                target.AddForce(10 * Vector2.left);
            }
        }
    }
}

