using UnityEngine;

namespace Kusume
{
    public class EnemyController : BaseMenheraController
    {
        [SerializeField]
        private PlayerController            player;

        //�U���̃J�E���g��i�߂�^�C�}�[
        private Timer                       attackTimer;
        public  Timer                       AttackTimer => attackTimer;

        [Header("�G�̍U���J�n�܂ł̃J�E���g"),SerializeField]
        private float                       attackCount;
        //�G���v���C���[���U������܂ł̃J�E���g���Ǘ����\������N���X
        [SerializeField]
        private EnemyAttackCount            enemyAttackCount;

        protected override MenheraBoard     Board => GameController.Instance.EnemyBoard;
        [SerializeField]
        private int                         skillCount;

        private void Awake()
        {
            enemyAttackCount = FindObjectOfType<EnemyAttackCount>();
            if(enemyAttackCount == null)
            {
                Debug.LogError("EnemyAttackCount���A�^�b�`����Ă��܂���");
            }
            
            attackTimer = new Timer(0);

        }

        private void Start()
        {
            player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                Debug.LogError("PlayerController��������܂���");
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
                }
            }
        }
    }
}
