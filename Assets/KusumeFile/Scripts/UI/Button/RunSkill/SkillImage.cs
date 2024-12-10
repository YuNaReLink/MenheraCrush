using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class SkillImage : MonoBehaviour
    {
        private Image image;
        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void SetSkillImageAndColor()
        {
            image.sprite = GameController.Instance.AllyDataInfo.faceSprite;
        }
    }
}
