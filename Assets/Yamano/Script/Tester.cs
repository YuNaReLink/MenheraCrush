using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //テスト用の適当なコンポーネント
    //入力担当
    public class Tester : MonoBehaviour
    {
        [SerializeField]
        CutIn prefab = null;
        [SerializeField]
        Canvas canvas = null;
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                Instantiate(prefab, canvas.transform, false);
            }
        }
    }
}

