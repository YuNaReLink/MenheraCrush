using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    /*�����Ȃ̂Ō�X�ύX����\��*/

    //�J�b�g�C���p�̃R���|�[�l���g
    //�J�b�g�C�����̓Q�[���̓������~�߂�̂Ń|�[�Y��v������B
    [RequireComponent(typeof(Pause))]
    public class CutIn : MonoBehaviour
    {
        /*Serialized*/

        //�J�b�g�C���̐�������
        //�J�E���g�A�b�v���Ȃ̂ł��̒l�͕s��
        [SerializeField]
        private float duration = 0.0f;

        [SerializeField]
        private Image image = null;

        [SerializeField]
        private RouteHolder route;

        /*Member*/

        //�o�ߎ���
        private float time = 0.0f;

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
            if (time >= duration)
            {
                //�|�[�Y�͔j�����ɖ����������B
                Destroy(gameObject);
                return;
            }

            if (image == null)
            {
                return;
            }
            image.rectTransform.localPosition = route.GetPosition(time);
        }
    }
}

