using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class AllySkillBackImage : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}
