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
            //�I�u�W�F�N�g�̐���
            GameObject o = new("BGM Player");

            //�R���|�[�l���g�̒ǉ�
            BGMPlayer player = o.AddComponent<BGMPlayer>();

            //�Đ��J�n
            player.Play(clip);
        }
    }
}
