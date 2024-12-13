using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class SkillButtonMask : MonoBehaviour
    {
        private Image image;

        [SerializeField]
        private float alpha = 0.7f;

        private void Awake()
        {
            image = GetComponentInChildren<Image>();
            Color c = image.color;
            c.a = alpha;
            image.color = c;
        }

        public void MaskUpdate(float current, float max)
        {
            float fillAmount = current / max;
            image.fillAmount = 1.0f - fillAmount;
        }

        public void SetState(bool state)
        {
            if (state)
            {
                image.fillAmount = 1.0f;
            }
        }
    }
}
