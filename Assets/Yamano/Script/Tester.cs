using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //�e�X�g�p�̓K���ȃR���|�[�l���g
    //���͒S��
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

