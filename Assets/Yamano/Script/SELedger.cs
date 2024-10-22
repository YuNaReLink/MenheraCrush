
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //効果音の台帳
    //ScriptableObjectとして定義している。
    [CreateAssetMenu(fileName = "SELedger", menuName = "ScriptableObjects/Ledger/SE", order = 1)]
    public class SELedger : LedgerBase<AudioClip>
    {
    }
}
