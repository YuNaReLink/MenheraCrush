using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Kusume 
{
    public class SkillButton : MonoBehaviour
    {
        private Image image;


        private Button button;

        private SkillImage skillImage;

        private SkillButtonMask mask;

        public SkillButtonMask Mask => mask;


        private RectTransform canvas;

        [SerializeField]
        private LucKee.CutIn cutIn;


        [SerializeField]
        private bool buttonMoveUI = false;
        private RectTransform rectTransform;

        private Vector2 baseRectPosition;

        private void Awake()
        {
            image = GetComponent<Image>();
            mask = GetComponentInChildren<SkillButtonMask>();
            skillImage = GetComponentInChildren<SkillImage>();
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if(gameCanvas != null)
            {
                canvas = gameCanvas.GetComponent<RectTransform>();
            }
            rectTransform = GetComponent<RectTransform>();
            baseRectPosition = rectTransform.anchoredPosition;
        }

        public void Setup(UnityAction action)
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(action);

            image.color = GameController.Instance.AllyData.imageColor;
            skillImage.SetSkillImageAndColor();
        }

        public void SetStateButton(bool state)
        {
            mask.SetState(state);
            if (!buttonMoveUI) { return; }
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
        }

        public void RunCutIn()
        {
            LucKee.CutIn c = Instantiate(cutIn, canvas.transform);
            c.SetSprite(GameController.Instance.AllyData.sprite);
        }
    }
}

