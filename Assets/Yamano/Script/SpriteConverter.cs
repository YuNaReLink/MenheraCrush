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
        /*Serialized*/

        //�t�H�[�}�b�g
        //{0}�̕����ɊG�����̔ԍ������邱�ƂɂȂ�B
        //0~9�c�c�s���N�F
        //10~19�c�c���F
        //���F���g�������ꍇ��{0}�̒��O��'1'������������10�ԑ�ɂ���ׂ��B
        [SerializeField]
        private String format = "<sprite index={0}>";

        /*Component*/

        //�Ώۂ̃e�L�X�g
        //����̐݌v�ł͓����I�u�W�F�N�g�ɕt���Ă���B
        private TextMeshProUGUI mesh;

        /*Event*/

        private void Awake()
        {
            mesh = GetComponent<TextMeshProUGUI>();
        }

        /*Method*/

        //������̕ύX
        //�����̕�����Ɋ܂܂�鐔����S�ăt�H�[�}�b�g�ɒu�������ĕύX����B
        public void SetText(String text)
        {
            //������10��ނ����Ȃ̂ŌŒ�l�ōs���B
            for (int i = 0; i < 10; i++)
            {
                //�e�������t�H�[�}�b�g�ɏ]���Ēu��������B
                text = text.Replace(i.ToString(), String.Format(format, i));
            }

            //��L�̏�����A�Ώۂ̃e�L�X�g�ɑ������B
            mesh.text = text;
        }

    }
}