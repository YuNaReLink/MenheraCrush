using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //�����̑䒠
    //ScriptableObject�Ƃ��Ē�`���Ă���B
    [CreateAssetMenu(fileName = "AudioLedger", menuName = "ScriptableObjects/Ledger/Audio", order = 1)]
    public class AudioLedger : LedgerBase<AudioClip>
    {
    }
}
