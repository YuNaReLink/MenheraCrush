using Kusume;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //�e�X�g�p�̓K���ȃR���|�[�l���g
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

