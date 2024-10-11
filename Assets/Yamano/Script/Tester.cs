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
        private Vector2 force = Vector2.up;
        [SerializeField]
        private Vector2 offset = Vector2.zero;
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                target.AddForceAtPosition(force, target.position + offset);
            }
        }
    }
}

