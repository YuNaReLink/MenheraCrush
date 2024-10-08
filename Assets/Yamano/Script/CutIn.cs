using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LucKee
{
    //�J�b�g�C���p�̃R���|�[�l���g
    //�摜��v������͖̂ܘ_�̂��ƁA�J�b�g�C�����̓Q�[���̓������~�߂�̂Ń|�[�Y���v������B
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Pause))]
    public class CutIn : MonoBehaviour
    {
        //�J�b�g�C���̎���
        [SerializeField]
        float duration = 0.0f;

        //�J�b�g�C�����n�܂������ɃQ�[�����ꎞ��~����B
        void Start()
        {
            Pause pause = GetComponent<Pause>();
            pause.Enable();
        }


        void Update()
        {
            //Time.timeScale�̉e�����󂯂Ȃ����ōX�V����B
            duration -= Time.unscaledDeltaTime;

            //�J�b�g�C���̏I�����ɔj������B
            if (duration <= 0)
            {
                //�|�[�Y�͔j�����ɖ����������B
                Destroy(gameObject);
            }
        }
    }
}

