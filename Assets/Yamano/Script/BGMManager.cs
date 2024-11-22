using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //BGMを流すためのクラス
    //コンポーネントとしては付けず、staticメソッドを呼び出すだけでBGMを再生する。
    public class BGMManager
    {
        //BGMの再生
        //再生用のオブジェクトを生成し、引数で受け取ったクリップを再生するように命令する。
        public static void Play(AudioClip clip)
        {
            //オブジェクトの生成
            GameObject o = new("BGM Player");

            //コンポーネントの追加
            BGMPlayer player = o.AddComponent<BGMPlayer>();

            //再生開始
            player.Play(clip);
        }
    }
}
