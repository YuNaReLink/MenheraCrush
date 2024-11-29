using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class SkillButtonMask : MonoBehaviour
    {
        [SerializeField]
        private float maskAlpha = 0.5f;
        private Image image;
        private void Awake()
        {
            image = GetComponentInChildren<Image>();
            Color c = image.color;
            c.a = 0.5f;
            image.color = c;
        }

        public void SetState(bool state)
        {
            float alpha;
            Color c = image.color;
            if (state)
            {
                alpha = maskAlpha;
            }
            else
            {
                alpha = 0.0f;
            }
            c.a = alpha;
            image.color = c;
        }
    }
}
