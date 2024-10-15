using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace LucKee
{
    //�s�[�X�̐F�Ɋւ�����
    [Serializable]
    public struct ColorInfo
    {
        //�^�O
        //TODO:�F��\��enum�^�ւ̕ύX
        public int tag;

        //�s�[�X�̐F
        //�摜�������ւ���ꍇ��Sprite�^�ɒu��������B
        public Color color;

        //�o������
        public float ratio;
    }

    //�s�[�X�̑傫���Ɋւ�����
    [Serializable]
    public struct SizeInfo
    {
        //�s�[�X�̑傫��
        public float size;

        //�s�[�X�j�󎞂̏Ռ��̋���
        public float power;

        //�o������
        public float ratio;
    }

    //�����_���Ȓl�̕ԋp�p�\����
    public struct PieceInfo
    {
        //�F���
        public ColorInfo color;

        //�T�C�Y���
        public SizeInfo size;
    }

    //�s�[�X�����p�̑䒠
    //[CreateAssetMenu(fileName = "PieceLedger", menuName = "ScriptableObjects/PieceLedger", order = 1)]
    public class PieceLedger : ScriptableObject
    {
        //�F���̑䒠
        [SerializeField]
        private ColorInfo[] colors;

        //�T�C�Y���̑䒠
        [SerializeField]
        private SizeInfo[] sizes;

        //�F�̏o�������̍��v
        private float sum_color = 0;

        //�T�C�Y�̏o�������̍��v
        private float sum_size = 0;

        //�����_��
        private Unity.Mathematics.Random random = new Unity.Mathematics.Random();

        //����������
        //�e�䒠�̏o�������̏W�v
        private void Initialize()
        {
            //�l�̏�����
            sum_color = 0;
            sum_size = 0;

            /*�W�v���[�v*/

            foreach (ColorInfo color in colors)
            {
                sum_color += color.ratio;
            }

            foreach (SizeInfo size in sizes)
            {
                sum_size += size.ratio;
            }
        }

        //�����p�s�[�X���̃����_���擾
        //���炩�̎��̂ŃG���[���o���ꍇ�͋�̏�ԂŕԂ��B
        public PieceInfo GetRandomPiece()
        {
            //�l��������ԂȂ珀��������B
            if (sum_color <= 0)
            {
                Initialize();
            }

            //�s�[�X���̏�����
            PieceInfo info = new PieceInfo();

            //�����_���ȐF(�̓Y����)���擾���A�G���[�l�Ȃ璆�f����B
            int colorIndex = GetRandomColor();
            if (colorIndex < 0)
            {
                return info;
            }

            //�����_���ȑ傫��(�̓Y����)���擾���A�G���[�l�Ȃ璆�f����B
            int sizeIndex = GetRandomSize();
            if (sizeIndex < 0)
            {
                return info;
            }

            //�G���[���o�Ă��Ȃ��̂Ŋe�ϐ��ɐݒ肵�ĕԂ��B
            info.color = colors[colorIndex];
            info.size = sizes[sizeIndex];
            return info;
        }

        //�����_���ȐF�̎擾
        //�Ԃ�l�͓Y����
        public int GetRandomColor()
        {
            //���v�����̃����_���ȏ����_���𐶐�����B
            float randomized = random.NextFloat() * sum_color;

            /*����*/
            for (int i = 0; i < colors.Length; i++)
            {
                //���������l���o�������̒l�������炷�B
                randomized -= colors[i].ratio;

                //���Z���ʂ�0�ȉ��Ȃ炻���Ŏ~�߂�B
                if (randomized <= 0)
                {
                    return i;
                }
            }

            //���炩�̃G���[��������������-1��Ԃ��B
            return -1;
        }

        //�����_���ȑ傫���̎擾
        //�Ԃ�l�͓Y����
        public int GetRandomSize()
        {
            //���v�����̃����_���ȏ����_���𐶐�����B
            float randomized = random.NextFloat() * sum_size;

            /*����*/
            for (int i = 0; i < sizes.Length; i++)
            {
                //���������l���o�������̒l�������炷�B
                randomized -= sizes[i].ratio;

                //���Z���ʂ�0�ȉ��Ȃ炻���Ŏ~�߂�B
                if (randomized <= 0)
                {
                    return i;
                }
            }

            //���炩�̃G���[��������������-1��Ԃ��B
            return -1;
        }
    }

}

