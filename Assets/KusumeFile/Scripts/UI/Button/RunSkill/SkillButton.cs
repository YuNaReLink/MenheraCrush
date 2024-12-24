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

        [SerializeField]
        private SkillButtonColorDataList colorDataList;

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

            button = GetComponent<Button>();
        }

        private void Start()
        {
            int num = (int)GameController.Instance.AllyDataInfo.tag;
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = colorDataList.ButtonColors[num].colors[(int)ButtonColor.Normal];
            colorBlock.highlightedColor = colorDataList.ButtonColors[num].colors[(int)ButtonColor.Highlighted];
            colorBlock.pressedColor = colorDataList.ButtonColors[num].colors[(int)ButtonColor.Pressed];
            colorBlock.selectedColor = colorDataList.ButtonColors[num].colors[(int)ButtonColor.Selected];
            colorBlock.disabledColor = colorDataList.ButtonColors[num].colors[(int)ButtonColor.Disabled];
            button.colors = colorBlock;
            skillImage.SetSkillImageAndColor();
        }

        public void Setup(UnityAction action)
        {
            //button = GetComponent<Button>();
            button.onClick.AddListener(action);
            /*
            int num = (int)GameController.Instance.AllyData.tag;
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = colorDataList.ButtonColors[num].colors[(int)ButtonColor.Normal];
            colorBlock.highlightedColor = colorDataList.ButtonColors[num].colors[(int)ButtonColor.Highlighted];
            colorBlock.pressedColor = colorDataList.ButtonColors[num].colors[(int)ButtonColor.Pressed];
            colorBlock.selectedColor = colorDataList.ButtonColors[num].colors[(int)ButtonColor.Selected];
            colorBlock.disabledColor = colorDataList.ButtonColors[num].colors[(int)ButtonColor.Disabled];
            button.colors = colorBlock;
            */

        }
        public void MaskUpdate(float current,float max)
        {
            mask.MaskUpdate(current,max);
        }

        public void SetStateButton(bool state)
        {
            mask.SetState(state);
            //ボタンを押した時に下に動く処理
            //フラグがtrueなら処理
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
            c.SetSprite(GameController.Instance.AllyDataInfo.sprite);
            AllySkillBackImage a = c.GetComponent<AllySkillBackImage>();
            a.SetSprite(GameController.Instance.AllyDataInfo.backSprite2);
        }
    }
}

