using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //BGM�𗬂����߂̃N���X
    //�R���|�[�l���g�Ƃ��Ă͕t�����Astatic���\�b�h���Ăяo��������BGM���Đ�����B
    public class BGMManager
    {
        //BGM�̍Đ�
        //�Đ��p�̃I�u�W�F�N�g�𐶐����A�����Ŏ󂯎�����N���b�v���Đ�����悤�ɖ��߂���B
        public static void Play(AudioClip clip)
        {
            if (clip == null) {
                Stop();
                return;
            }

            BGMPlayer player = BGMPlayer.Instance;

            if (player == null)
            {
                player = new GameObject("BGM Player").AddComponent<BGMPlayer>();
            }

            //�Đ��J�n
            player.Play(clip);
        }

        //BGM�̒�~
        public static void Stop()
        {
            BGMPlayer.Instance?.Stop();
        }
    }
}
