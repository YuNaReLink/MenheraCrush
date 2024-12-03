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

        protected override MenheraBoard     Board => GameController.Instance.EnemyBoard;
        [SerializeField]
        private int                         actionRatio;

        private void Awake()
        {
            enemyAttackCount = FindObjectOfType<EnemyAttackCount>();
            if(enemyAttackCount == null)
            {
                Debug.LogError("EnemyAttackCountがアタッチされていません");
            }
            
            attackTimer = new Timer(0);

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
            if (GameController.Instance.IsPuzzleStop || GameController.Instance.IsEndGame) { return; }
            float time = Time.deltaTime;
            /*
            if (Input.GetKey(KeyCode.Alpha2))
            {
                time *= 1.5f;
            }
             */
            attackTimer.Update(time);
        }
        private void Attack()
        {
            enemyAttackCount.CountUpdate();
            if(enemyAttackCount.Count <= 0)
            {
                int random = GetRandomAction();
                if (random <= actionRatio / 2)
                {
                    player.HP.Decrease(10);
                }
                else
                {
                    Instantiate(menheraData.Characters[charaInt].skill, transform.position, Quaternion.identity);
                }
                
            }
        }

        public int GetRandomAction()
        {
            int randomized = Random.Range(0, actionRatio+1);
            
            return randomized;
        }
    }
}
