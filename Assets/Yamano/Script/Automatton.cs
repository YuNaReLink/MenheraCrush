using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee {
    //�e�X�g�p�̓K���ȃR���|�[�l���g
    //����S��
    public class Automatton : MonoBehaviour
    {
        //�ړ�����~�̔��a
        [SerializeField]
        float radius = 1.0f;
        
        //���݂̊p�x
        float radian = 0.0f;
        
        //�b�Ԃ̊p�x�̕ω��l
        [SerializeField]
        float radianSpeed = 1.0f;


        private void Update()
        {
            //�p�x�̍X�V
            //�|�[�Y�̃e�X�g�̂��߁ATime.timeScale�̉e�����󂯂���ōX�V����B
            radian += radianSpeed * Time.deltaTime;

            //�ʒu�̌v�Z
            Vector2 v = Vector2.one * radius;
            v.x *= Mathf.Cos(radian);
            v.y *= Mathf.Sin(radian);

            //�ʒu�̍X�V
            transform.position = v;
        }
    }
}

