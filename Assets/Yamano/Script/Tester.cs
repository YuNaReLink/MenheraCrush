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
        private SpriteRenderer targetRenderer = null;
        [SerializeField]
        private float rotation = 0.0f;

        private Material material = null;
        private void Awake()
        {
            material = targetRenderer.material;
        }
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                target.AddForce(10 * Vector2.left);
            }
            rotation += Time.deltaTime;
            material.SetFloat("_Rotation", rotation);
        }
    }
}

