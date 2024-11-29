using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //キーフレーム
    //Unity製の既存のものでは情報量が多すぎたので自作。
    [Serializable]
    public struct Keyframe2D
    {
        //時間
        public float time;

        //位置
        public Vector2 position;
    }

    //キーフレームを読むためだけのクラス
    [Serializable]
    public class RouteHolder
    {
        /*Serialized*/

        //本体
        [SerializeField]
        private Keyframe2D[] keys;

        /*Method*/

        //所要時間の取得
        //自身が持つキーフレームの最後の時間を返す。
        public float GetDuration()
        {
            //要素が無い場合は0を返す。
            if (keys.Length <= 0)
            {
                return 0;
            }
            return keys[^1].time;
        }

        //位置の取得
        //本体の時間の範囲と引数の関係によって挙動が変わる。
        //・本体の長さが0の場合、引数に拘わらず(0, 0)を返す。
        //・引数が本体[0]のtime以下の場合、[0]のpositionを返す。
        //・引数が本体[^1]のtime以上の場合、[^1]のpositionを返す。
        //・上記のいずれでもない場合、引数を挟むtimeを持つ2つの値から計算する。
        public Vector2 GetPosition(float time)
        {
            //本体が無いので(0, 0)を返す。
            if (keys.Length <= 0)
            {
                return Vector2.zero;
            }

            //[0]以下なので計算を省いて返す。
            if (time <= keys[0].time)
            {
                return keys[0].position;
            }
            //[^1]以上なので計算を省いて返す。
            if (time >= keys[^1].time)
            {
                return keys[^1].position;
            }

            //計算を省けないと判断したので渋々ループを回す。
            //引数を挟む2つの値を探すため、ループ回数を本体の長さから1回減らして回している。
            for (int i = 0; i < keys.Length - 1; i++)
            {
                //iとi+1の間に挟まれていないなら次に行く。
                if (time > keys[i + 1].time)
                {
                    continue;
                }

                //挟まれている間の長さを1とした引数の進捗の割合を求める。
                float progress = (time - keys[i].time) / (keys[i + 1].time - keys[i].time);

                //上記の割合を基に位置を求めて返す。
                Vector2 v = keys[i].position + (keys[i + 1].position - keys[i].position) * progress;
                return v;
            }

            //ここまで来た場合はエラーだと考えるべきだが、最終的な地点を返すことにした。
            return keys[^1].position;
        }
    }
}
