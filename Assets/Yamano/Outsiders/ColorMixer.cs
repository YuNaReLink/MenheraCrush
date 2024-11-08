using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //�F����`�⊮���邽�߂̃N���X
    public class ColorMixer
    {
        //�ŏ��̐F
        //�擾���̈�����0������Ƃ��̐F�ɂȂ�B
        private Color start = Color.white;
        //�Ō�̐F
        //�擾���̈�����1������Ƃ��̐F�ɂȂ�B
        private Color end = Color.white;

        //�F�̐ݒ�
        public void SetColor(Color s, Color e)
        {
            start = s;
            end = e;
        }

        //�F�̎擾
        //�������w�肵�A����ɉ����č������F��Ԃ��B
        public Color GetColor(float progress)
        {
            if (progress <= 0)
            {
                return start;
            }
            if (progress >= 1)
            {
                return end;
            }

            Color color = start;

            Color diff = end - start;
            color += diff * progress;

            return color;
        }

    }
}