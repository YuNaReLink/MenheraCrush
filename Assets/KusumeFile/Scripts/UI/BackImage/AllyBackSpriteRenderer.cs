using UnityEngine;

namespace Kusume
{
    public class AllyBackSpriteRenderer : MonoBehaviour
    {
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
