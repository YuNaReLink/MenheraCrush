
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    [CreateAssetMenu(fileName = "SELedger", menuName = "ScriptableObjects/SELedger", order = 1)]
    public class SELedger : ScriptableObject
    {
        [SerializeField]
        private AudioClip[] ledger;
        public AudioClip this[int i] { get => ledger[i]; }
        public int Count { get=>ledger.Length; }
    }
}
