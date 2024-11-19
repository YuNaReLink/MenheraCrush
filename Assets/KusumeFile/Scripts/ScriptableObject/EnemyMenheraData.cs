using Kusume;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [Serializable]
    public struct EnemyAttackCountInfo
    {
        public float attackCount;
    }

    [CreateAssetMenu(fileName = "EnemyMenheraInfo", menuName = "ScriptableObjects/EnemyMenheraInfo", order = 2)]
    public class EnemyMenheraData : ScriptableObject
    {
        [SerializeField]
        private EnemyAttackCountInfo[] enemyAttackCountInfos;
        public EnemyAttackCountInfo[] EnemyAttackCountInfos => enemyAttackCountInfos;

    }
}
