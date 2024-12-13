using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //テスト用の適当なコンポーネント
    public class Tester : MonoBehaviour
    {
        [SerializeField]
        private Shaker shaker;

        private void Awake()
        {
            shaker.Activate();
        }
        private void Update()
        {
            if (Input.anyKey)
            {
                shaker.Deactivate();
            }
        }

    }
}

