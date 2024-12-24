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

        private float                       power;

        [Header("�G�̍U���J�n�܂ł̃J�E���g"),SerializeField]
        private float                       attackCount;
        //�G���v���C���[���U������܂ł̃J�E���g���Ǘ����\������N���X
        [SerializeField]
        private EnemyAttackCount            enemyAttackCount;
        [SerializeField]
        private EnemySkillCutIn             enemySkillCutIn;

        protected override MenheraBoard     board => GameController.Instance.EnemyBoard;
        [SerializeField]
        private int                         skillCount;

        [SerializeField]
        private int                         activateAllSkillCount;

        [SerializeField]
        private AllSkillData allSkillData;

        private void Awake()
        {
            /*
            enemyAttackCount = FindObjectOfType<EnemyAttackCount>();
            if(enemyAttackCount == null)
            {
                Debug.LogError("EnemyAttackCount���A�^�b�`����Ă��܂���");
            }
            
            attackTimer = new Timer(0);
             */

        }

        private void Start()
        {
            enemyAttackCount = FindObjectOfType<EnemyAttackCount>();
            if (enemyAttackCount == null)
            {
                Debug.LogError("EnemyAttackCount���A�^�b�`����Ă��܂���");
            }
            enemySkillCutIn = enemyAttackCount.GetComponent<EnemySkillCutIn>();

            attackTimer = new Timer(0);
            player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                Debug.LogError("PlayerController��������܂���");
            }

            SetCharaInt((int)SelectStageContainer.EnemyCharacter);

            SetMenheraUI();
            power = menheraData.Characters[charaInt].skillGauge;
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

            if (Input.GetKeyDown(KeyCode.P))
            {
                ActivateSkill();
                enemySkillCutIn.RunSkill();
                skillCount = 0;
            }
        }
        private void Attack()
        {
            enemyAttackCount.CountUpdate();
            if(enemyAttackCount.Count <= 0)
            {
                skillCount++;
                if(skillCount >= 3)
                {
                    ActivateSkill();
                    enemySkillCutIn.RunSkill();
                    skillCount = 0;
                }
                else
                {
                    player.HP.Decrease((int)power);
                    player.Board.DamageUI.ColorChangeStart();
                }
            }
        }

        private void ActivateSkill()
        {
            if(charaInt >= (int)CharacterNameList.PlayebleCount)
            {
                Instantiate(menheraData.Characters[charaInt].skill, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(allSkillData.Skills[activateAllSkillCount], transform.position, Quaternion.identity);
                activateAllSkillCount++;
                if(activateAllSkillCount > 1)
                {
                    activateAllSkillCount = 0;
                }
            }
        }
    }
}
