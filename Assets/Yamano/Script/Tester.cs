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
        TransitionCloser prefab;


        private void Update()
        {
            if (Input.anyKeyDown)
            {
                TransitionCloser closer = Instantiate(prefab);
                closer.SetNext(SceneList.Title);
            }
        }
    }
}

