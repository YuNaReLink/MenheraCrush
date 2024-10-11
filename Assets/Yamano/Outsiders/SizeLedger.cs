using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //ピースの大きさに関する情報を扱う構造体
    //SerializeFieldとして使えるようにする属性を付けている。
    [Serializable]
    public struct SizeInfo
    {
        //大きさ
        //sizeが1の場合、最終的な半径は0.5になる。
        [SerializeField]
        public float size;

        //ピース破壊時の衝撃の大きさ
        //0にすることで衝撃が発生しなくなる。
        [SerializeField]
        public float power;

        //出現割合
        //(この値÷配列内の割合の値の合計)が出現率になる。
        //100などに合わせる必要は特に無い。
        [SerializeField]
        public float ratio;
    }

    //サイズ情報の台帳
    [CreateAssetMenu(fileName = "SizeLedger", menuName = "ScriptableObjects/SizeLedger", order = 1)]
    public class SizeLedger : ScriptableObject
    {
        //台帳の本体
        [SerializeField]
        private SizeInfo[] ledger;

        //割合の合計
        //初期化時のみ書き込みが発生し、以降は全て読み取りしかしない。
        private float ratioSum = 0.0f;

        //初回参照時の準備処理
        //合計値を初期化したうえで出現率を合計する。
        private void Initialize()
        {
            ratioSum = 0.0f;
            foreach (SizeInfo info in ledger)
            {
                ratioSum += info.ratio;
            }
        }

        //サイズ情報のランダム取得
        public SizeInfo GetRandomInfo()
        {
            //割合の合計が0以下であることはあり得ないので初期化する。
            if (ratioSum <= 0.0f)
            {
                Initialize();
            }

            //合計値を最大として乱数を用意する。
            float randomized = UnityEngine.Random.Range(0, ratioSum);

            //台帳の走査
            for (int i = 0; i < ledger.Length; i++)
            {
                //出現割合を基に乱数を減らす。
                randomized -= ledger[i].ratio;

                //減らしたことによって0以下になった場合はそこで止める。
                if (randomized <= 0)
                {
                    return ledger[i];
                }
            }

            //ここまで見つからなかったのでエラー値として空の構造体を返す。
            return new SizeInfo();
        }

    }
}
