using UnityEngine;

namespace Kusume
{
    public class SetStageInfoData : MonoBehaviour
    {
        [SerializeField]
        private StageInfoData               stageInfoData;

        private ScoreViewGauge              scoreViewGauge;

        private EnemyController             enemyController;

        private LucKee.EnteringLeader       enteringLeader;

        [SerializeField]
        private Transform                   gameCanvasTransform;

        [SerializeField]
        private GameObject                  gameStartObject;

        private PlayerController playerController;
        private WindSpace                   windSpace;
        private void Awake()
        {
            scoreViewGauge = FindObjectOfType<ScoreViewGauge>();

            enemyController = GetComponent<EnemyController>();

            enteringLeader = FindObjectOfType<LucKee.EnteringLeader>();

            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if( gameCanvas != null)
            {
                gameCanvasTransform = gameCanvas.transform;
            }
            playerController = FindObjectOfType<PlayerController>();
            windSpace = FindObjectOfType<WindSpace>();

        }

        private void Start()
        {
            if (scoreViewGauge != null)
            {
                scoreViewGauge.SetMaxScoreFill(stageInfoData.StageInfos[(int)SelectStageContainer.EnemyCharacter].goalScore);
            }
            if (enemyController != null)
            {
                enemyController.LoopAttackStart(stageInfoData.StageInfos[(int)SelectStageContainer.EnemyCharacter].attackCount);
            }

            GameController.Instance.SetGameTimer(stageInfoData.StageInfos[(int)SelectStageContainer.EnemyCharacter].gameTime);

            if(enteringLeader != null)
            {
                enteringLeader.Jump();
            }

            SetGameStartCountDown();

            windSpace.SetPlayerController(playerController);
        }

        private void SetGameStartCountDown()
        {
            GameObject gameobject = Instantiate(gameStartObject, gameCanvasTransform.position, Quaternion.identity);
            gameobject.transform.SetParent(gameCanvasTransform);
            Destroy(this);
        }
    }
}
