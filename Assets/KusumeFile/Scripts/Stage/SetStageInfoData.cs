using LucKee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class SetStageInfoData : MonoBehaviour
    {
        [SerializeField]
        private StageInfoData stageInfoData;

        private ScoreViewGauge scoreViewGauge;

        private EnemyController enemyController;

        private EnteringLeader enteringLeader;

        private void Awake()
        {
            scoreViewGauge = FindObjectOfType<ScoreViewGauge>();

            enemyController = GetComponent<EnemyController>();

            enteringLeader = FindObjectOfType<EnteringLeader>();
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
            Destroy(this);
        }
    }
}
