using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    /// <summary>
    /// �w�i�ɔz�u���Ă�X�R�A��UI�ŕ\�����Ă���̂ɏ������s���N���X
    /// </summary>
    public class ScoreViewGauge : MonoBehaviour
    {
        [SerializeField]
        private float               maxGauge;

        [SerializeField]
        private float               goalGauge;

        [SerializeField]
        private RectTransform       fillRectTransform;

        [SerializeField]
        private Image               fillImage;

        [SerializeField]
        private LucKee.GaugeFill    fill;

        private void Awake()
        {
            fillImage = fillRectTransform.gameObject.GetComponentInChildren<Image>();
            fill = GetComponentInChildren<LucKee.GaugeFill>();
        }
        private void Start()
        {
            RectTransform myRect = GetComponent<RectTransform>();

            fillImage.fillAmount = 0;

            float c = goalGauge;
            GameScore.InitCount((int)c);

            
        }

        public void SetMaxScoreFill(float goal)
        {
            fill.SetGoalRatio(goal / maxGauge);
        }

        private void Update()
        {
            UpdateGauge();
        }

        private void UpdateGauge()
        {
            float p = GameScore.GetProgress();
            if(p > 1.0f)
            {
                p = 1.0f;
            }
            fillImage.fillAmount = p;
        }
    }
}
