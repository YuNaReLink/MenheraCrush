using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    /*�����Ȃ̂Ō�X�ύX����\��*/

    //�J�b�g�C���p�̃R���|�[�l���g
    public class CutIn : MonoBehaviour
    {
        /*Serialized*/

        //�J�b�g�C���̐�������
        //�J�E���g�A�b�v���Ȃ̂ł��̒l�͕s��
        //���̒l�̕����������ꍇ�A�ړ��o�H����������D�悷��B
        [SerializeField]
        private float duration = 0.0f;

        //�ړ��Ώۂ̉摜
        [SerializeField]
        private Image image = null;

        //�摜�̈ړ��o�H
        [SerializeField]
        private RouteHolder route;

        /*Member*/

        //�o�ߎ���
        private float time = 0.0f;


        private MonoBehaviour after = null;

        private Skill skillObject;
        public void SetSkill(Skill skill) 
        {
            skillObject = skill; 
            skillObject.enabled = false;
        }

        /*Event*/

        void Start()
        {
            time = 0.0f;
            route.SetOffset(image.rectTransform.localPosition);
            image.rectTransform.localPosition = route.GetPosition(0.0f);
        }

        void Update()
        {
            //Time.timeScale�̉e�����󂯂Ȃ����ōX�V����B
            time += Time.unscaledDeltaTime;

            //�J�b�g�C���̏I�����ɔj������B
            if (time >= duration && time >= route.GetDuration())
            {
                Finish();
                return;
            }

            if (image == null)
            {
                return;
            }
            image.rectTransform.localPosition = route.GetPosition(time);
        }

        /*Method*/

        //�J�b�g�C�����ɓ����摜�̕ύX
        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }

        //�J�b�g�C���I����ɐ������������̂�ݒ肷��B
        public void SetAfter(MonoBehaviour mono)
        {
            after = mono;
        }

        //�J�b�g�C���̏I��
        //�I����̐�����I�u�W�F�N�g�̔j�����s���B
        //�|�[�Y�͔j�����ɖ����������B
        private void Finish()
        {
            if (after != null)
            {
                Instantiate(after);
            }
            if(skillObject != null)
            {
                skillObject.enabled = true;
            }
            Destroy(gameObject);
        }
    }
}

