using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //[CreateAssetMenu(fileName = "__Ledger", menuName = "ScriptableObjects/Ledger/__", order = 1)]
    public abstract class LedgerBase<T> : ScriptableObject
    {
        [SerializeField]
        private T[] values;
        public T[] Values { get => values; }
        public T this[int i] { get => values[i]; }
        public int Count { get => values.Length; }
    }
}