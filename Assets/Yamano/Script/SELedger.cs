
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //効果音の台帳
    //ScriptableObjectとして定義している。
    [CreateAssetMenu(fileName = "SELedger", menuName = "ScriptableObjects/SELedger", order = 1)]
    public class SELedger : ScriptableObject
    {
        //台帳の本体
        [SerializeField]
        private AudioClip[] ledger;

        //アクセス用のインデクサー
        public AudioClip this[int i] { get => ledger[i]; }

        //登録した効果音の個数
        public int Count { get=>ledger.Length; }
    }
}
