using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

namespace LucKee
{

    //sss->100
    //ssl->110
    //sll->120
    //lll->130
    //~~~s->10n
    //~~~l->30n
    public class ScoreCalculator : MonoBehaviour
    {
        private static ScoreCalculator instance = null;
        private static ScoreCalculator Instance
        {
            get
            {
                //�ݒ�Y��p
                if (instance == null)
                {
                    instance = new GameObject("ScoreCalculator").AddComponent<ScoreCalculator>();
                }
                return instance;
            }
        }

        //false:small
        //true:large
        //�X�R�A�̌v�Z
        //�s�[�X�̑召�Ƃ��̏��ԁA�X�R�A�{�[�i�X�̗L�����󂯎���Čv�Z����B
        //�召��true����Afalse�����ƂȂ��Ă���B
        //�ݒ�����₷���悤��MonoBehaviour��p���邪�A�v�Z�ȊO���s��Ȃ�����static�ŃA�N�Z�X�ł���悤�ɂ��A�V���O���g���̖{�̂Ōv�Z����悤�ɂ��Ă���B
        public static int Calc(List<bool> sizes, bool bonus = false)
        {
            return Instance.CalcExecute(sizes, bonus);
        }

        //��b�X�R�A
        [SerializeField]
        private int baseScore = 100;

        //��b�X�R�A�ւ̉��Z
        //�q�����ŏ���3�̂����A�傫���s�[�X1�ɂ�1����Z�����B
        [SerializeField]
        private int baseScorePerLarge = 10;

        //�ǉ��X�R�A(��)
        //4�ڈȍ~�̃s�[�X�̂����A�傫���s�[�X1�ɂ�1����Z�����B
        [SerializeField]
        private int additionalScoreLarge = 30;

        //�ǉ��X�R�A(��)
        //4�ڈȍ~�̃s�[�X�̂����A�������s�[�X1�ɂ�1����Z�����B
        [SerializeField]
        private int additionalScoreSmall = 10;

        //��b�{�[�i�X
        //�X�R�A�{�[�i�X���������Ă���ꍇ�A��b�X�R�A�Ɠ��l�ɉ��Z�����B
        [SerializeField]
        private int baseBonus = 10;

        //�ǉ��{�[�i�X
        //�X�R�A�{�[�i�X���������Ă���ꍇ�A(�召��킸)4�ڈȍ~�̃s�[�X1�ɂ�1����Z�����B
        [SerializeField]
        private int additionalBonus = 5;

        //�V���O���g���p
        private void Awake()
        {
            instance = this;
        }

        //�v�Z�̖{��
        //static�̃��\�b�h����̂݌Ă΂��B
        private int CalcExecute(List<bool> sizes, bool bonus)
        {
            //��b�X�R�A�ŏ���������B
            int score = baseScore;

            //�X�R�A�{�[�i�X���Ȃ瓯���Ƀ{�[�i�X�����Z����B
            if (bonus)
            {
                //��b�{�[�i�X
                score += baseBonus;

                //�ǉ��{�[�i�X
                score += (sizes.Count - 3) * additionalBonus;
            }

            //�ŏ���3�̂����A�傫���s�[�X�̐������X�R�A�����Z����B
            for (int i = 0; i < 3; i++)
            {
                if (sizes[i])
                {
                    score += baseScorePerLarge;
                }
            }

            //4�ڈȍ~�̌v�Z
            for (int i = 3; i < sizes.Count; i++)
            {
                //�T�C�Y����
                if (sizes[i])
                {
                    //��
                    score += additionalScoreLarge;
                }
                else
                {
                    //��
                    score += additionalScoreSmall;
                }
            }
            //�v�Z���ʂ�Ԃ��B
            return score;
        }
    }
}