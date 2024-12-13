using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //�e�X�g�p�̓K���ȃR���|�[�l���g
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

