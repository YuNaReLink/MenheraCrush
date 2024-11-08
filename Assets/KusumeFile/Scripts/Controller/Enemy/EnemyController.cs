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

        private void Awake()
        {
            player = FindObjectOfType<PlayerController>();
            if(player == null)
            {
                Debug.LogError("PlayerControllerが見つかりません");
            }
            attackTimer = new Timer();
        }


        private void Start()
        {
            SetThisUI();

            LoopAttackStart();
        }

        private void SetThisUI()
        {
            thisImage.sprite = enemyData.Characters[(int)SelectStageContainer.EnemyCharacter].sprite;
            thisImage.SetNativeSize();
            RectTransform rectTransform = thisImage.GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        private void LoopAttackStart()
        {
            attackTimer.SetLoop(true);
            attackTimer.Start(2.0f);
            attackTimer.OnEnd += DecreaseHP;
        }

        
        private void Update()
        {
            attackTimer.Update();
        }
        private void DecreaseHP()
        {
            player.HP.Decrease(10);
        }
    }
}
