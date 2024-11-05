using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LucKee
{
    //���W(��Ƀs�[�X)���m���q����
    //�������̉摜��z�肵�Ă���B
    [RequireComponent(typeof(SpriteRenderer))]
    public class PieceConnector : MonoBehaviour
    {
        //���̎n�_
        [SerializeField]
        private Transform start;

        //���̏I�_
        [SerializeField]
        private Transform end;

        //�n�_�ƏI�_��ݒ肵�A�ʒu��␳����B
        public void Initialize(Transform s, Transform e)
        {
            start = s;
            end = e;
            CorrectPosition();
        }

        //�ʒu���v�Z��������B
        private void Update()
        {
            //���΂ɖ����Ƃ͎v�����G���[�΍�
            if (start == null || start.IsDestroyed())
            {
                Destroy(gameObject);
                return;
            }
            if (end == null || end.IsDestroyed())
            {
                Destroy(gameObject);
                return;
            }
            CorrectPosition();
        }

        //�ʒu�̕␳
        private void CorrectPosition()
        {
            //���̎擾
            Vector2 diff = start.position - end.position;

            //�p�x�̌v�Z
            float angle = Mathf.Atan2(diff.y, diff.x);
            angle *= Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = rotation;

            //�ʒu�̌v�Z
            transform.position = (start.position + end.position) * 0.5f;

            //�傫���̌v�Z
            Vector3 scale = transform.localScale;
            scale.x = diff.magnitude;
            transform.localScale = scale;

        }
    }
}