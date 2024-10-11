using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //�s�[�X�̑傫���Ɋւ�����������\����
    //SerializeField�Ƃ��Ďg����悤�ɂ��鑮����t���Ă���B
    [Serializable]
    public struct SizeInfo
    {
        //�傫��
        //size��1�̏ꍇ�A�ŏI�I�Ȕ��a��0.5�ɂȂ�B
        [SerializeField]
        public float size;

        //�s�[�X�j�󎞂̏Ռ��̑傫��
        //0�ɂ��邱�ƂŏՌ����������Ȃ��Ȃ�B
        [SerializeField]
        public float power;

        //�o������
        //(���̒l���z����̊����̒l�̍��v)���o�����ɂȂ�B
        //100�Ȃǂɍ��킹��K�v�͓��ɖ����B
        [SerializeField]
        public float ratio;
    }

    //�T�C�Y���̑䒠
    [CreateAssetMenu(fileName = "SizeLedger", menuName = "ScriptableObjects/SizeLedger", order = 1)]
    public class SizeLedger : ScriptableObject
    {
        //�䒠�̖{��
        [SerializeField]
        private SizeInfo[] ledger;

        //�����̍��v
        //���������̂ݏ������݂��������A�ȍ~�͑S�ēǂݎ�肵�����Ȃ��B
        private float ratioSum = 0.0f;

        //����Q�Ǝ��̏�������
        //���v�l�����������������ŏo���������v����B
        private void Initialize()
        {
            ratioSum = 0.0f;
            foreach (SizeInfo info in ledger)
            {
                ratioSum += info.ratio;
            }
        }

        //�T�C�Y���̃����_���擾
        public SizeInfo GetRandomInfo()
        {
            //�����̍��v��0�ȉ��ł��邱�Ƃ͂��蓾�Ȃ��̂ŏ���������B
            if (ratioSum <= 0.0f)
            {
                Initialize();
            }

            //���v�l���ő�Ƃ��ė�����p�ӂ���B
            float randomized = UnityEngine.Random.Range(0, ratioSum);

            //�䒠�̑���
            for (int i = 0; i < ledger.Length; i++)
            {
                //�o����������ɗ��������炷�B
                randomized -= ledger[i].ratio;

                //���炵�����Ƃɂ����0�ȉ��ɂȂ����ꍇ�͂����Ŏ~�߂�B
                if (randomized <= 0)
                {
                    return ledger[i];
                }
            }

            //�����܂Ō�����Ȃ������̂ŃG���[�l�Ƃ��ċ�̍\���̂�Ԃ��B
            return new SizeInfo();
        }

    }
}
