using LucKee;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class GameStartTimerUI : MonoBehaviour
    {
        private RectTransform   rectTransform;

        private SpriteConverter converter;

        [SerializeField]
        private GameObject      StartUI;

        private float             currentTime = 0;

        [SerializeField]
        private float baseScale = 0;

        [SerializeField]
        private float endScale = 1.0f;

        [SerializeField]
        private float lerpTime = 5.0f;

        private void Awake()
        {
            converter = GetComponent<SpriteConverter>();
            rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            GameStarter starter = GameStarter.Instance;
            if (starter.GameStartTimer.IsEnd())
            {
                GameObject g = Instantiate(StartUI,transform.position, Quaternion.identity);
                g.transform.SetParent(transform.parent);
                Destroy(gameObject);
                return;
            }
            currentTime = starter.GameStartTimer.Current;
            ChangeCountUpdate();
            int count = (int)starter.GameStartTimer.Current + 1;
            converter.SetText(count.ToString());
        }

        private void ChangeCountUpdate()
        {
            float fractionalPart = currentTime - Mathf.Floor(currentTime);
            if(fractionalPart <= 0.5f)
            {
                Vector3 scale = rectTransform.localScale;
                scale = Vector3.Lerp(scale, Vector3.one * endScale, Time.deltaTime * lerpTime);
                rectTransform.localScale = scale;
            }
            else
            {
                Vector3 scale = rectTransform.localScale;
                scale = Vector3.zero;
                rectTransform.localScale = scale * baseScale;
            }
        }
    }
}
