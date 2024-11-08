using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private PlayerController    player;


        private Timer               attackTimer;

        [SerializeField]
        private MenheraData         enemyData;
        [SerializeField]
        private Image               thisImage;

        [SerializeField]
        private Animator            animator;

        [SerializeField]
        private EnemyAttackCount enemyAttackCount;

        private void Awake()
        {
            player = FindObjectOfType<PlayerController>();
            if(player == null)
            {
                Debug.LogError("PlayerController‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
            }
            attackTimer = new Timer();

            enemyAttackCount = FindObjectOfType<EnemyAttackCount>();
        }


        private void Start()
        {
            SetThisUI();

            LoopAttackStart();
        }

        private void SetThisUI()
        {
            thisImage.sprite = enemyData.Characters[(int)SelectStageContainer.EnemyCharacter].sprite;
            thisImage.color = Color.white;
            thisImage.SetNativeSize();
            RectTransform rectTransform = thisImage.GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        private void LoopAttackStart()
        {
            attackTimer.SetLoop(true);
            attackTimer.Start(10.0f);
            attackTimer.OnEnd += Attack;
        }

        
        private void Update()
        {
            attackTimer.Update();
        }
        private void Attack()
        {
            enemyAttackCount.CountUpdate();
            if(enemyAttackCount.Count <= 0)
            {
                player.HP.Decrease(10);
                //Instantiate(enemyData.Characters[(int)SelectStageContainer.EnemyCharacter].skill, transform.position, Quaternion.identity);
            }
        }
    }
}
