using UnityEngine;

namespace Kusume
{
    public class EnemyController : BaseMenheraController
    {
        [SerializeField]
        private PlayerController    player;


        private Timer               attackTimer;
        public  Timer               AttackTimer => attackTimer;

        [Header("敵の攻撃開始までのカウント"),SerializeField]
        private float               attackCount = 11.5f;

        [SerializeField]
        private EnemyMenheraData    enemyMenheraData;

        [SerializeField]
        private EnemyAttackCount    enemyAttackCount;

        protected override MenheraBoard Board => GameController.Instance.EnemyBoard;

        private void Awake()
        {
            enemyAttackCount = FindObjectOfType<EnemyAttackCount>();
            if(enemyAttackCount == null)
            {
                Debug.LogError("EnemyAttackCountがアタッチされていません");
            }
            
            attackTimer = new Timer();

        }


        private void Start()
        {
            player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                Debug.LogError("PlayerControllerが見つかりません");
            }

            SetCharaInt((int)SelectStageContainer.EnemyCharacter);

            SetMenheraUI();

            attackCount = enemyMenheraData.EnemyAttackCountInfos[charaInt].attackCount;

            LoopAttackStart();
        }

        private void LoopAttackStart()
        {
            attackTimer.SetLoop(true);
            attackTimer.Start(attackCount);
            attackTimer.OnEnd += Attack;
        }

        
        private void Update()
        {
            if (GameController.Instance.IsPuzzleStop || GameController.Instance.IsEndGame) { return; }
            attackTimer.Update();
        }
        private void Attack()
        {
            enemyAttackCount.CountUpdate();
            if(enemyAttackCount.Count <= 0)
            {
                player.HP.Decrease(10);
                
            }
        }
    }
}
