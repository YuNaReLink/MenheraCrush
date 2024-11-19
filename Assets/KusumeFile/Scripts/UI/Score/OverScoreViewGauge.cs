using UnityEngine;

namespace Kusume
{
    public class OverScoreViewGauge : MonoBehaviour
    {
        [SerializeField]
        private ScoreViewGauge scoreViewGauge;

        private float maxGauge;

        [SerializeField]
        private float goalGauge = 10000000.0f;

        [SerializeField]
        private RectTransform fillRectTransform;

        private void Awake()
        {
            scoreViewGauge = GetComponentInParent<ScoreViewGauge>();
        }
        // Start is called before the first frame update
        void Start()
        {
            RectTransform myRect = GetComponent<RectTransform>();
            maxGauge = Mathf.Abs(myRect.sizeDelta.y);


            GameScore.InitOverCount((int)goalGauge);
        }

        // Update is called once per frame
        void Update()
        {
            if (GameScore.GetProgress() < 1.0f)
            {
                return;
            }
            UpdateGauge();
        }

        private void UpdateGauge()
        {
            float p = GameScore.GetOverProgress();
            if (p > 1.0f)
            {
                p = 1.0f;
            }
            float scale = 0;
            scale = p * maxGauge;
            Vector2 v = fillRectTransform.sizeDelta;
            fillRectTransform.sizeDelta = new Vector2(v.x, scale);
        }
    }
}
