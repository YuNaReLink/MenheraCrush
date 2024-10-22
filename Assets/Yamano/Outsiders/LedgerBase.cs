using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //[CreateAssetMenu(fileName = "__Ledger", menuName = "ScriptableObjects/Ledger/__", order = 1)]
    public abstract class LedgerBase<T> : ScriptableObject
    {
        [SerializeField]
        public T[] Values { get; }
        public T this[int i] { get => Values[i]; }
    }
}