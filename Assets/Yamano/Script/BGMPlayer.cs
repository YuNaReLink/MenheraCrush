using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //BGM���Đ����邽�߂̃R���|�[�l���g
    //�Ǘ��N���X����̂݌Ă΂�A�R�[�h��Ő������邽�߃v���n�u�����s��Ȃ��B
    //BGM�͓�����1�܂ł�������Ȃ��z��ł���A�V���O���g���ō쐬���Ă��邽�߃N���X�t�F�[�h�Ȃǂ͑Ή����Ă��Ȃ��B
    //�������������߁AAudioSource��v������B
    [RequireComponent(typeof(AudioSource))]
    public class BGMPlayer : MonoBehaviour
    {
        /*static*/

        //�B��̃C���X�^���X
        public static BGMPlayer Instance { get; private set; }

        /*Component*/

        private new AudioSource audio = null;

        public void SetVolume(float v) { audio.volume = v; }

        /*Event*/

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            //���ɗ���Ă���ꍇ�A����BGM�������B
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }

            //�������A���g���B��̃C���X�^���X�ƂȂ�B
            Instance = this;

            //�R���|�[�l���g�̎擾�y�у��[�v�ݒ�
            audio = GetComponent<AudioSource>();
            audio.loop = true;
        }

        //�j�����ABGM�̒�~�Ƌ��ɗB��̍����~���B
        private void OnDestroy()
        {
            audio.Stop();
            if(Instance == this)
            {
                Instance = null;
            }
        }

        /*Method*/

        //�Đ��̊J�n
        //�w�肵���N���b�v���Đ�����B
        public void Play(AudioClip clip)
        {
            audio.clip = clip;
            audio.Play();
        }

        //��~
        public void Stop()
        {
            audio.Stop();
        }

        //���݂�BGM���ŏ��ɖ߂��B
        public void Restart()
        {
            audio.Play();
        }

        //�N���b�v�̎擾(YAGNI)
        public AudioClip GetClip() { return audio.clip; }
    }

}
