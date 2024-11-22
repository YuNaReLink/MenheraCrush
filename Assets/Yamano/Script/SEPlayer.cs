using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //���ʉ���炷���߂����̃R���|�[�l���g
    //��̃I�u�W�F�N�g�Ɋ���t���Ďg���O��̂��߁A��I���ƃI�u�W�F�N�g���Ə�����B
    //���R�Ȃ���炷���߂̋@�\��v������B
    [RequireComponent(typeof(AudioSource))]
    public class SEPlayer : MonoBehaviour
    {
        /*Component*/

        //�{��
        private AudioSource source = null;

        /*Event*/

        private void Awake()
        {
            //�������ɋ@�\���擾���Ă����B
            source = GetComponent<AudioSource>();
        }

        private void Update()
        {
            //���Ă��Ȃ���Ώ�����B
            if (!source.isPlaying)
            {
                Destroy(gameObject);
            }
        }

        /*Method*/

        //�N���b�v���w�肵�čĐ�����B
        public void Play(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }

    }
}
