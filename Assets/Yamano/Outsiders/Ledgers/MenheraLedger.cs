using System;
using UnityEngine;

namespace LucKee
{
    /*
     */
    [Serializable]
    public struct MenheraInfo
    {
        //TODO:Change type to enum.
        public int tag;

        public String name;

        //public AnimatorController wait;

        public Skill skill;

        public TextAsset text;

        public bool canBeAlly;

    }
    [CreateAssetMenu(fileName = "MenheraLedger", menuName = "ScriptableObjects/Ledger/Menhera", order = 1)]
    public class MenheraLedger : LedgerBase<MenheraInfo>
    {
    }
}