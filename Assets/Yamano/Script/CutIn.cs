using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    /*�����Ȃ̂Ō�X�ύX����\��*/

    //�J�b�g�C���p�̃R���|�[�l���g
    //�J�b�g�C�����̓Q�[���̓������~�߂�̂Ń|�[�Y��v������B
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Pause))]
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

        /*Event*/

        void Start()
        {
            //�J�b�g�C�����n�܂������ɃQ�[�����ꎞ��~����B
            Pause pause = GetComponent<Pause>();
            pause.Enable();

            time = 0.0f;
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

        public void SetAfter(MonoBehaviour mono)
        {
            after = mono;
        }
        private void Finish()
        {
            if (after != null)
            {
                Instantiate(after);
            }

            //�|�[�Y�͔j�����ɖ����������B
            Destroy(gameObject);
        }
    }
}

