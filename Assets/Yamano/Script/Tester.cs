using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //テスト用の適当なコンポーネント
    public class Tester : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem particle;


        private void Update()
        {
            if (Input.anyKeyDown)
            {
                particle.Play();
            }
        }
    }
}

