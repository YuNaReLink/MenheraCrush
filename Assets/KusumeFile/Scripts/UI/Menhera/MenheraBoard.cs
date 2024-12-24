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

        private DamageUI damageUI;
        public DamageUI DamageUI => damageUI;

        public void Init(CharacterInfo characterInfo)
        {
            //アニメーターの設定
            animator.SetInteger("Number",characterInfo.characterNumber);
            //画像の設定
            image.sprite = characterInfo.sprite;
            //画像のカラーを設定
            image.color = Color.white;
            //大きさを設定
            rectTransform.localScale *= characterInfo.ImageScale;
            //画像にあった大きさに設定
            image.enabled = true;

            basePosition = rectTransform.anchoredPosition;
            Vector2 pos =basePosition;
            pos += characterInfo.ImageOffset;
            rectTransform.anchoredPosition = pos;

            image.SetNativeSize();
        }

        private void Awake()
        {
            image = GetComponent<Image>();

            animator = GetComponent<Animator>();

            rectTransform = GetComponent<RectTransform>();

            damageUI = GetComponent<DamageUI>();
        }

        private void Start()
        {
            image.enabled = false;
        }
    }
}
