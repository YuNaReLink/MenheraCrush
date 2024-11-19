using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //テスト用の適当なコンポーネント
    public class Tester : MonoBehaviour
    {
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                SEManager manager = GetComponent<SEManager>();
                manager.Play(0);
            }
        }
    }
}

