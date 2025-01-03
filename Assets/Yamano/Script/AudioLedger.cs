using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //音源の台帳
    //ScriptableObjectとして定義している。
    [CreateAssetMenu(fileName = "AudioLedger", menuName = "ScriptableObjects/Ledger/Audio", order = 1)]
    public class AudioLedger : LedgerBase<AudioClip>
    {
    }
}
