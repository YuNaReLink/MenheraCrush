using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //色を線形補完するためのクラス
    public class ColorMixer
    {
        //最初の色
        //取得時の引数に0を入れるとこの色になる。
        private Color start = Color.white;
        //最後の色
        //取得時の引数に1を入れるとこの色になる。
        private Color end = Color.white;

        //色の設定
        public void SetColor(Color s, Color e)
        {
            start = s;
            end = e;
        }

        //色の取得
        //割合を指定し、それに応じて混ぜた色を返す。
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