using Kusume;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [CreateAssetMenu(fileName = "EnemyMenheraInfo", menuName = "ScriptableObjects/EnemyMenheraInfo", order = 2)]
    public class EnemyMenheraData : ScriptableObject
    {
        [SerializeField]
        private EnemyAttackCountInfo[] enemyAttackCountInfos;
        public EnemyAttackCountInfo[] EnemyAttackCountInfos => enemyAttackCountInfos;

    }
}
