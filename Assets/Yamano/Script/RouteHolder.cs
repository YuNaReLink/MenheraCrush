using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //�L�[�t���[��
    //Unity���̊����̂��̂ł͏��ʂ����������̂Ŏ���B
    [Serializable]
    public struct Keyframe2D
    {
        //����
        public float time;

        //�ʒu
        public Vector2 position;
    }

    //�L�[�t���[����ǂނ��߂����̃N���X
    [Serializable]
    public class RouteHolder
    {
        /*Serialized*/

        //�{��
        [SerializeField]
        private Keyframe2D[] keys;

        /*Method*/

        //���v���Ԃ̎擾
        //���g�����L�[�t���[���̍Ō�̎��Ԃ�Ԃ��B
        public float GetDuration()
        {
            //�v�f�������ꍇ��0��Ԃ��B
            if (keys.Length <= 0)
            {
                return 0;
            }
            return keys[^1].time;
        }

        //�ʒu�̎擾
        //�{�̂̎��Ԃ͈̔͂ƈ����̊֌W�ɂ���ċ������ς��B
        //�E�{�̂̒�����0�̏ꍇ�A�����ɍS��炸(0, 0)��Ԃ��B
        //�E�������{��[0]��time�ȉ��̏ꍇ�A[0]��position��Ԃ��B
        //�E�������{��[^1]��time�ȏ�̏ꍇ�A[^1]��position��Ԃ��B
        //�E��L�̂�����ł��Ȃ��ꍇ�A����������time������2�̒l����v�Z����B
        public Vector2 GetPosition(float time)
        {
            //�{�̂������̂�(0, 0)��Ԃ��B
            if (keys.Length <= 0)
            {
                return Vector2.zero;
            }

            //[0]�ȉ��Ȃ̂Ōv�Z���Ȃ��ĕԂ��B
            if (time <= keys[0].time)
            {
                return keys[0].position;
            }
            //[^1]�ȏ�Ȃ̂Ōv�Z���Ȃ��ĕԂ��B
            if (time >= keys[^1].time)
            {
                return keys[^1].position;
            }

            //�v�Z���Ȃ��Ȃ��Ɣ��f�����̂ŏa�X���[�v���񂷁B
            //����������2�̒l��T�����߁A���[�v�񐔂�{�̂̒�������1�񌸂炵�ĉ񂵂Ă���B
            for (int i = 0; i < keys.Length - 1; i++)
            {
                //i��i+1�̊Ԃɋ��܂�Ă��Ȃ��Ȃ玟�ɍs���B
                if (time > keys[i + 1].time)
                {
                    continue;
                }

                //���܂�Ă���Ԃ̒�����1�Ƃ��������̐i���̊��������߂�B
                float progress = (time - keys[i].time) / (keys[i + 1].time - keys[i].time);

                //��L�̊�������Ɉʒu�����߂ĕԂ��B
                Vector2 v = keys[i].position + (keys[i + 1].position - keys[i].position) * progress;
                return v;
            }

            //�����܂ŗ����ꍇ�̓G���[���ƍl����ׂ������A�ŏI�I�Ȓn�_��Ԃ����Ƃɂ����B
            return keys[^1].position;
        }
    }
}
