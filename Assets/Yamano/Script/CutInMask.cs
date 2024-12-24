using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    //�J�b�g�C���̃}�X�N�p�̃R���|�[�l���g
    //����0(�C�ӁARectTransform�ˑ�)����n�܂�A�ڕW�l�܂ň�葬�x�ōL����悤�ɍ���Ă���B
    //�}�X�N�@�\���g�����߁AMask��Image��v������B
    [RequireComponent(typeof(Mask))]
    [RequireComponent(typeof(Image))]
    public class CutInMask : MonoBehaviour
    {
        /*Serialized*/

        //�ŏI�I�ȍ���
        //Canvas��ł̒l�Ȃ̂ő傫��������B
        [SerializeField]
        private float goalHeight = 100.0f;

        //�L���鑬��
        //�b��
        [SerializeField]
        private float widenSpeed = 200.0f;

        [SerializeField]
        private Image background = null;

        /*Component*/

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Update()
        {
            //���݂̑傫�����擾����B
            Vector2 size = image.rectTransform.sizeDelta;

            //�J�b�g�C������Time.timeScale��0�ɂ��Ă��邽�߁A���̉e�����󂯂Ȃ����ŏ������s���B
            float delta = Time.unscaledDeltaTime;

            //������L�΂��B
            size.y += widenSpeed * delta;

            //����������؂�̂Ă�B
            if (goalHeight < size.y)
            {
                size.y = goalHeight;
            }

            //�傫������꒼���B
            image.rectTransform.sizeDelta = size;

            //�ڕW�l�܂œ��B�����Ȃ�R���|�[�l���g��j������B
            //��L�̏����̊֌W�ŁA���̎��_�ŖڕW�l�𒴂��邱�Ƃ͖������߁A���l���Z�q�ł��B
            if (goalHeight <= size.y)
            {
                Destroy(this);
            }
        }
        public void SetBackSprite(Sprite sprite)
        {
            background.sprite = sprite;
            background.SetNativeSize();
            float ratio = image.rectTransform.rect.width / background.rectTransform.rect.width;
            background.rectTransform.localScale = ratio * Vector2.one;
        }
    }
}