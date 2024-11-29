using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class CountDelay : MonoBehaviour
    {
        private EnemyController enemyController;

        [SerializeField]
        private float addCount = 5.0f;

        private void Awake()
        {
            enemyController = FindAnyObjectByType<EnemyController>();
        }

        private void OnDestroy()
        {
            enemyController.AttackTimer.AddCurrent(addCount);
        }
    }
}
