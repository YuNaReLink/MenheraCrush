using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //�e�X�g�p�̓K���ȃR���|�[�l���g
    //���͒S��
    public class Tester : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D target = null;
        [SerializeField]
        private Vector2 force = Vector2.up;
        [SerializeField]
        private Vector2 offset = Vector2.zero;
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                target.AddForceAtPosition(force, target.position + offset);
            }
        }
    }
}

