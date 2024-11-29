using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Kusume 
{
    public class SkillButton : MonoBehaviour
    {
        private Button button;

        private SkillButtonMask mask;

        public SkillButtonMask Mask => mask;

        /*
        private RectTransform rectTransform;

        private Vector2 baseRectPosition;
        */

        private void Awake()
        {
            mask = GetComponentInChildren<SkillButtonMask>();
            //rectTransform = GetComponent<RectTransform>();
            //baseRectPosition = rectTransform.anchoredPosition;
        }

        public void Setup(UnityAction action)
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(action);
        }

        public void SetStateButton(bool state)
        {
            mask.SetState(state);
            /*
            if (state)
            {
                rectTransform.anchoredPosition = baseRectPosition;
            }
            else
            {
                Vector2 pos = baseRectPosition;
                pos.y += 10;
                rectTransform.anchoredPosition = pos;
            }
             */
        }
    }
}

