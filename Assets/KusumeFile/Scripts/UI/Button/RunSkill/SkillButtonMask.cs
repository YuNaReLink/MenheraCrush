using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class SkillButtonMask : MonoBehaviour
    {
        private Image image;
        private void Awake()
        {
            image = GetComponentInChildren<Image>();
            Color c = image.color;
            c.a = 0.5f;
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
