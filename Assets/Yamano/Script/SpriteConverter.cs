using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LucKee
{
    //���p������S�ĊG�����ɕϊ����ĕ\�����邽�߂̃R���|�[�l���g
    //�G�����Ή��̂��߁A�s�{�ӂȂ���TextMeshPro��p���Ď������Ă���B
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SpriteConverter : MonoBehaviour
    {
        /*
         * �e�G�����͖��̂őΉ����Ă���A���L�̒ʂ�̏����ň������Ƃ��ł���B
         * �E��ɐF���w�肷��B(Black�y��Pink)
         * �E��ɕ������w�肷��B(�e�����y�уR���}�A�R����)
         * ��Ƃ��āATextMeshPro��<sprite name=Black0>�Ɠ��͂����ꍇ�A����0�ɂ�����G�������\�������B
        */

        /*static*/

        //���̊G����
        private static readonly String Black = "Black";

        //�s���N�̊G����
        private static readonly String Pink = "Pink";

        //�ϊ��Ώ�
        //�ϊ����镶���S�Ă��Ђƌq���̕�����ŕێ����Ă���B
        private static readonly String Convertion = "0123456789,:";

        //�G�����𖼏̂ŌĂяo�����߂̃t�H�[�}�b�g
        //�ϐ�����Format�Ƃ������������AString.Format�Ƃ̍���������邽�߂Ɏg�p���T�����B
        private static readonly String Sentence = "<sprite name={0}>";

        /*Serialized*/

        //���ƃs���N�̐؂�ւ����s���t���O
        [SerializeField]
        private bool black = false;

        /*Component*/

        //�Ώۂ̃e�L�X�g
        //����̐݌v�ł͓����I�u�W�F�N�g�ɕt���Ă���B
        private TextMeshProUGUI mesh;

        /*Event*/

        private void Awake()
        {
            mesh = GetComponent<TextMeshProUGUI>();
            //For the test.
            //SetText("0123456789,:");
        }

        /*Method*/

        //������̕ύX
        //�����̕�����Ɋ܂܂�鐔����S�ăt�H�[�}�b�g�ɒu�������ĕύX����B
        public void SetText(String text)
        {
            //�O�ɕt��������̔��f
            String title;
            if (black)
            {
                title = Black;
            }
            else
            {
                title = Pink;
            }

            for (int i = 0; i < Convertion.Length; i++)
            {
                //�ϊ��Ώۂ̕���
                String before = Convertion[i].ToString();

                //�ϊ���̕�����
                String after = String.Format(Sentence, title + before);

                //�e�������t�H�[�}�b�g�ɏ]���Ēu��������B
                text = text.Replace(before, after);
            }

            //��L�̏�����A�Ώۂ̃e�L�X�g�ɑ������B
            mesh.text = text;
        }

    }
}