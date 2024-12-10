using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Animator))]
    public class MenheraBoard : MonoBehaviour
    {
        private RectTransform rectTransform;

        private Vector2 basePosition;

        private Image image;

        private Animator animator;

        private bool entry = false;

        public void Init(CharacterInfo characterInfo)
        {
            animator.runtimeAnimatorController = characterInfo.animator;

            image.sprite = characterInfo.sprite;
            image.color = Color.white;
            image.SetNativeSize();
            image.enabled = true;

            basePosition = rectTransform.anchoredPosition;
            Vector2 pos =basePosition;
            pos += characterInfo.ImageOffset;
            rectTransform.anchoredPosition = pos;
        }

        private void Awake()
        {
            image = GetComponent<Image>();

            animator = GetComponent<Animator>();

            rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            image.enabled = false;
        }

        private void EntryUpdate()
        {
            if (!entry) { return; }

        }
    }
}
