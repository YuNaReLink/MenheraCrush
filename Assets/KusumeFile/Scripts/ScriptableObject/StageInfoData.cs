using Kusume;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [Serializable]
    public struct StageInfo
    {
        public float attackCount;
        public float gameTime;
        public float goalScore;
    }

    [CreateAssetMenu(fileName = "StageInfoData", menuName = "ScriptableObjects/StageInfoData", order = 2)]
    public class StageInfoData : ScriptableObject
    {
        [SerializeField]
        private StageInfo[] stageInfos;
        public StageInfo[] StageInfos => stageInfos;

    }
}
