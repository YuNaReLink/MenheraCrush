using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class ScoreViewGauge : MonoBehaviour
    {
        private float maxGauge;

        [SerializeField]
        private float goalGauge = 500.0f;

        [SerializeField]
        private RectTransform fillRectTransform;

        [SerializeField]
        private Image fillImage;

        private void Awake()
        {
            fillImage = fillRectTransform.gameObject.GetComponentInChildren<Image>();
        }
        // Start is called before the first frame update
        void Start()
        {
            RectTransform myRect = GetComponent<RectTransform>();

            fillImage.fillAmount = 0;

            float c = goalGauge;
            GameScore.InitCount((int)c);
        }

        // Update is called once per frame
        void Update()
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
            //float scale = 0;
            //scale = p * maxGauge;
            //Vector2 v = fillRectTransform.sizeDelta;
            //fillRectTransform.sizeDelta = new Vector2(v.x, scale);
        }
    }
}
