using UnityEngine;

namespace Kusume
{
    public class CountDelay : MonoBehaviour, LucKee.ISkillObject
    {
        private EnemyController enemyController;

        [SerializeField]
        private float addCount = 5.0f;

        private void Awake()
        {
            enemyController = FindAnyObjectByType<EnemyController>();
        }

        public void Execute()
        {
            enemyController.AttackTimer.AddCurrent(addCount);
        }
    }
}
