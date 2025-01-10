using Kusume;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //テスト用の適当なコンポーネント
    public class Tester : MonoBehaviour
    {
        [SerializeField]
        RubyableText text;
        [SerializeField]
        String main;
        [SerializeField]
        String ruby;
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                text.SetText(main, ruby);
            }
        }
    }
}

