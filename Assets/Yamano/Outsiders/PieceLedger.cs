using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace LucKee
{
    //ピースの色に関する情報
    [Serializable]
    public struct ColorInfo
    {
        //タグ
        //TODO:色を表すenum型への変更
        public int tag;

        //ピースの色
        //画像を差し替える場合はSprite型に置き換える。
        public Color color;

        //出現割合
        public float ratio;
    }

    //ピースの大きさに関する情報
    [Serializable]
    public struct SizeInfo
    {
        //ピースの大きさ
        public float size;

        //ピース破壊時の衝撃の強さ
        public float power;

        //出現割合
        public float ratio;
    }

    //ランダムな値の返却用構造体
    public struct PieceInfo
    {
        //色情報
        public ColorInfo color;

        //サイズ情報
        public SizeInfo size;
    }

    //ピース生成用の台帳
    //[CreateAssetMenu(fileName = "PieceLedger", menuName = "ScriptableObjects/PieceLedger", order = 1)]
    public class PieceLedger : ScriptableObject
    {
        //色情報の台帳
        [SerializeField]
        private ColorInfo[] colors;

        //サイズ情報の台帳
        [SerializeField]
        private SizeInfo[] sizes;

        //色の出現割合の合計
        private float sum_color = 0;

        //サイズの出現割合の合計
        private float sum_size = 0;

        //ランダム
        private Unity.Mathematics.Random random = new Unity.Mathematics.Random();

        //初期化処理
        //各台帳の出現割合の集計
        private void Initialize()
        {
            //値の初期化
            sum_color = 0;
            sum_size = 0;

            /*集計ループ*/

            foreach (ColorInfo color in colors)
            {
                sum_color += color.ratio;
            }

            foreach (SizeInfo size in sizes)
            {
                sum_size += size.ratio;
            }
        }

        //生成用ピース情報のランダム取得
        //何らかの事故でエラーが出た場合は空の状態で返す。
        public PieceInfo GetRandomPiece()
        {
            //値が初期状態なら準備をする。
            if (sum_color <= 0)
            {
                Initialize();
            }

            //ピース情報の初期化
            PieceInfo info = new PieceInfo();

            //ランダムな色(の添え字)を取得し、エラー値なら中断する。
            int colorIndex = GetRandomColor();
            if (colorIndex < 0)
            {
                return info;
            }

            //ランダムな大きさ(の添え字)を取得し、エラー値なら中断する。
            int sizeIndex = GetRandomSize();
            if (sizeIndex < 0)
            {
                return info;
            }

            //エラーが出ていないので各変数に設定して返す。
            info.color = colors[colorIndex];
            info.size = sizes[sizeIndex];
            return info;
        }

        //ランダムな色の取得
        //返り値は添え字
        public int GetRandomColor()
        {
            //合計未満のランダムな小数点数を生成する。
            float randomized = random.NextFloat() * sum_color;

            /*走査*/
            for (int i = 0; i < colors.Length; i++)
            {
                //生成した値を出現割合の値だけ減らす。
                randomized -= colors[i].ratio;

                //減算結果が0以下ならそこで止める。
                if (randomized <= 0)
                {
                    return i;
                }
            }

            //何らかのエラーが発生したため-1を返す。
            return -1;
        }

        //ランダムな大きさの取得
        //返り値は添え字
        public int GetRandomSize()
        {
            //合計未満のランダムな小数点数を生成する。
            float randomized = random.NextFloat() * sum_size;

            /*走査*/
            for (int i = 0; i < sizes.Length; i++)
            {
                //生成した値を出現割合の値だけ減らす。
                randomized -= sizes[i].ratio;

                //減算結果が0以下ならそこで止める。
                if (randomized <= 0)
                {
                    return i;
                }
            }

            //何らかのエラーが発生したため-1を返す。
            return -1;
        }
    }

}

