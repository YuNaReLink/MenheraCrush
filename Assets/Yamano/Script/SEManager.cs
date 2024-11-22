using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //���ʉ����Đ����邽�߂̃R���|�[�l���g
    //�Đ�������ʉ���\�ߑ䒠��ScriptableObject�ɓo�^���Ă����K�v������B
    //�p�r�ɂ���Ďg����������悤�ɔ�static�ō���Ă���B
    public class SEManager : MonoBehaviour
    {

        /*Serialized*/

        //�䒠
        [SerializeField]
        private AudioLedger ledger;

        /*Method*/

        //�Đ����邽�߂����̃I�u�W�F�N�g�𐶐�����B
        //�ԍ��w��Ȃ̂ŊԈႢ�ɒ��ӁB
        public void Play(int i)
        {
            //�ԍ����͈͊O�Ȃ疳������B
            if (i < 0 || i >= ledger.Count)
            {
                return;
            }

            //��̃I�u�W�F�N�g�𐶐�����B
            GameObject o = new("SE Player");

            //�R���|�[�l���g������t����B
            SEPlayer se = o.AddComponent<SEPlayer>();

            //�炷�B
            se.Play(ledger[i]);
        }

    }
}

