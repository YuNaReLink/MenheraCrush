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
            //�A�j���[�^�[�̐ݒ�
            animator.SetInteger("Number",characterInfo.characterNumber);
            //�摜�̐ݒ�
            image.sprite = characterInfo.sprite;
            //�摜�̃J���[��ݒ�
            image.color = Color.white;
            //�傫����ݒ�
            rectTransform.localScale *= characterInfo.ImageScale;
            //�摜�ɂ������傫���ɐݒ�
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
