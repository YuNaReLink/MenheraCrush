using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //���ꎞ�̓�����擱����I�u�W�F�N�g
    //��̃I�u�W�F�N�g�Ɋ���t���Ďg���B
    //�d�͂��������߁ARigidbody2D��v������B
    //�I�����ɏ����邽�߁A���̃R���|�[�l���g��t���Ă͂����Ȃ��B
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnteringLeader : MonoBehaviour
    {
        //�B��̃C���X�^���X
        public static EnteringLeader Instance { get; private set; }

        //y���W�̕␳
        //���ۂɂ̓I�u�W�F�N�g��y���W��������B
        //�擾�̊ȈՉ��y�уC���X�^���X�̍폜��ł����Ă��s����N�����Ȃ��悤��static�ɕێ����Ă���B
        public static float OffsetY { get; private set; }

        //������ւ̗�
        //������Ɏ��g����ɑł��グ��B
        [SerializeField]
        private float power = 1.0f;
        [SerializeField]
        private bool jumpOnStart = false;

        private Rigidbody2D rigid = null;

        private void Awake()
        {
            Instance = this;
            rigid = GetComponent<Rigidbody2D>();
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        private void Start()
        {
            if (jumpOnStart)
            {
                Jump();
            }
        }
        private void Update()
        {
            //y���W�݂̂��擾����B
            float y = transform.position.y;

            //0������������ɂ͏I������B
            if (y < 0)
            {
                y = 0;
                Destroy(gameObject);
            }

            //static���ɑ������B
            //���ɔj����ł������Ƃ��Ă��A���[�J���ϐ���static�ϐ��Ȃ̂Ŗ��Ȃ�����ł���B
            OffsetY = y;
        }


        private void OnDestroy()
        {
            Instance = null;
        }


        public void Jump()
        {
            if (rigid.constraints == RigidbodyConstraints2D.None)
            {
                return;
            }
            rigid.constraints = RigidbodyConstraints2D.None;
            //��ɑł��グ��B
            rigid.AddForce(power * Vector2.up, ForceMode2D.Impulse);
        }
    }
}