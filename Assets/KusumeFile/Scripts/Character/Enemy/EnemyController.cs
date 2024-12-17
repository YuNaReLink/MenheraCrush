using UnityEngine;

namespace Kusume
{
    public class EnemyController : BaseMenheraController
    {
        [SerializeField]
        private PlayerController            player;

        //攻撃のカウントを進めるタイマー
        private Timer                       attackTimer;
        public  Timer                       AttackTimer => attackTimer;

        [Header("敵の攻撃開始までのカウント"),SerializeField]
        private float                       attackCount;
        //敵がプレイヤーを攻撃するまでのカウントを管理＆表示するクラス
        [SerializeField]
        private EnemyAttackCount            enemyAttackCount;

        protected override MenheraBoard     board => GameController.Instance.EnemyBoard;
        [SerializeField]
        private int                         skillCount;

        private void Awake()
        {
            /*
            enemyAttackCount = FindObjectOfType<EnemyAttackCount>();
            if(enemyAttackCount == null)
            {
                Debug.LogError("EnemyAttackCountがアタッチされていません");
            }
            
            attackTimer = new Timer(0);
             */

        }

        private void Start()
        {
            enemyAttackCount = FindObjectOfType<EnemyAttackCount>();
            if (enemyAttackCount == null)
            {
                Debug.LogError("EnemyAttackCountがアタッチされていません");
            }

            attackTimer = new Timer(0);
            player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                Debug.LogError("PlayerControllerが見つかりません");
            }

            SetCharaInt((int)SelectStageContainer.EnemyCharacter);

            SetMenheraUI();
        }

        public void LoopAttackStart(float time)
        {
            attackCount = time;
            attackTimer.SetLoop(true);
            attackTimer.Start(time);
            attackTimer.OnEnd += Attack;
        }

        
        private void Update()
        {
            if (!GameController.Instance.IsPlayable()) { return; }
            float time = Time.deltaTime;

            attackTimer.Update(time);
        }
        private void Attack()
        {
            enemyAttackCount.CountUpdate();
            if(enemyAttackCount.Count <= 0)
            {
                skillCount++;
                if(skillCount >= 3)
                {
                    Instantiate(menheraData.Characters[charaInt].skill, transform.position, Quaternion.identity);
                    skillCount = 0;
                }
                else
                {
                    player.HP.Decrease(10);
                    player.Board.DamageUI.ColorChangeStart();
                }
            }
        }
    }
}
