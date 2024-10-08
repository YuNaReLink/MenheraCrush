
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //���ʉ��̑䒠
    //ScriptableObject�Ƃ��Ē�`���Ă���B
    [CreateAssetMenu(fileName = "SELedger", menuName = "ScriptableObjects/SELedger", order = 1)]
    public class SELedger : ScriptableObject
    {
        //�䒠�̖{��
        [SerializeField]
        private AudioClip[] ledger;

        //�A�N�Z�X�p�̃C���f�N�T�[
        public AudioClip this[int i] { get => ledger[i]; }

        //�o�^�������ʉ��̌�
        public int Count { get=>ledger.Length; }
    }
}
