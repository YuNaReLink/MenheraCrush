using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //テスト用の適当なコンポーネント
    public class Tester : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvas = null;
        [SerializeField]
        private CutIn cut = null;



        private void Update()
        {
            if (Input.anyKeyDown)
            {
                Instantiate(cut, canvas.transform);
            }
        }
    }
}

