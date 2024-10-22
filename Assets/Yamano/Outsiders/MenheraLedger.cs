using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    [Serializable]
    public struct MenheraInfo
    {
        //TODO:Change type to enum.
        public int Tag { get; }

        public String Name { get; }

        public Sprite Face { get; }
        public Sprite Body { get; }
        public Skill Skill { get; }

        public TextAsset Text { get; }

        public bool CanBeAlly { get; }

    }
    //[CreateAssetMenu(fileName = "MenheraLedger", menuName = "ScriptableObjects/Ledger/Menhera", order = 1)]
    public class MenheraLedger : LedgerBase<MenheraInfo>
    {
    }
}