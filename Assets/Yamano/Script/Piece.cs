using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //�s�[�X�̎��ʃ^�O
    //�����Ȃ̂Ō�X�ς��B
    enum PieceTag
    {
        Null,
        Piece0,
        Piece1,
        Piece2,
        Piece3,
        Count
    }


    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    //�s�[�X�p�R���|�[�l���g(����)
    //�j��������ǂ��A�Q�l�ɂ�����ǂ��B
    public class Piece : MonoBehaviour
    {
        //�s�[�X�̃T�C�Y�ꗗ
        private static float[] Size = { 1.0f, 2.0f };

        //�s�[�X�̔����͈ꗗ
        private static float[] Power = { 0.0f, 1.0f };

        //�s�[�X�̔����͈͈ꗗ
        private static float[] Radius = { 0.0f, 1.0f };

        //�s�[�X�̎��ʃ^�O
        [SerializeField]
        private new PieceTag tag = PieceTag.Null;

        //�s�[�X�̃T�C�Y�ԍ�
        [SerializeField]
        int sizeIndex = 0;

        //�s�[�X�̔j��܂ł̑ҋ@����
        float wait = 0;
        
        //������̏���
        //�^�O��T�C�Y�̕s�������m�����ꍇ�͑����ɔj�󂷂�B
        private void Start()
        {
            //�^�O����
            if (tag == PieceTag.Null)
            {
                Destroy(gameObject);
                return;
            }
            
            //�T�C�Y����
            if (sizeIndex < 0 || sizeIndex >= Size.Length)
            {
                Destroy(gameObject);
                return;
            }

            //�T�C�Y�ԍ�����Ƀs�[�X�̃T�C�Y��ύX����
            transform.localScale = Vector3.one * Size[sizeIndex];
            
            //�s�[�X�̎�ނɂ���ĉ摜���F��ύX����̂łƂ肠�����擾
            //SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        }

        //�X�V����
        //�ҋ@���Ԃ��I��������j�󂷂�B
        private void Update()
        {
            //�ҋ@���ł͂Ȃ��̂Œ��f
            if (wait <= 0)
            {
                return;
            }

            //�|�[�Y���̓J�E���g��i�߂Ȃ��悤�ATime.timeScale�̉e�����󂯂�����g���B
            wait -= Time.deltaTime;

            //�ҋ@���Ԃ��I��������j�󂷂�B
            if (wait <= 0)
            {
                Crush();
            }
        }

        //�j�󏈗�
        //�����ɔj�󂷂�B
        public void Crush()
        {
            Impact();
            Destroy(gameObject);
        }

        //�j�󏈗�
        //�ҋ@����(�b)���w�肵�Ĕj�󂷂�B
        public void Crush(float w)
        {
            //0�ȉ��̏ꍇ�͑ҋ@�����ɔj�󂷂�B
            if (w <= 0)
            {
                Crush();
                return;
            }

            //�ҋ@���Ԃ�ݒ肵�A�c���Update�ɔC����B
            wait = w;
        }

        //�j�󎞂ɋN����Ռ��̏���
        private void Impact()
        {
            //�T�C�Y�ԍ�����ɔ����͂��擾����B
            float power = Power[sizeIndex];

            //0�ȉ��Ȃ甭�������Ȃ��B
            if (power <= 0)
            {
                return;
            }

            //�T�C�Y�ԍ�����ɔ����̔��a���擾����B
            float radius = Radius[sizeIndex];

            //�E���g�𒆐S��
            //�E��L�̔��a����
            //
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, new Vector2());

            foreach (RaycastHit2D hit in hits)
            {
                Vector2 diff = hit.point - (Vector2)transform.position;
                Rigidbody2D rigid = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                if (rigid == null)
                {
                    continue;
                }
                Vector2 force = diff.normalized;
                force *= power;
                rigid.AddForce(force);
            }
        }
    }
}
