using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class AllyBackSpriteRenderer : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}
