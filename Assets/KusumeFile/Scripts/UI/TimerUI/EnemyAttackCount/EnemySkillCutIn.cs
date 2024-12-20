using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class EnemySkillCutIn : MonoBehaviour
    {
        [SerializeField]
        private LucKee.CutIn cutIn;

        private RectTransform canvas;


        private void Awake()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if (gameCanvas != null)
            {
                canvas = gameCanvas.GetComponent<RectTransform>();
            }
        }

        public void RunSkill()
        {
            LucKee.CutIn c = Instantiate(cutIn, canvas.transform);
            //c.SetSprite(GameController.Instance.EnemyDataInfo.sprite);
        }
    }
}
