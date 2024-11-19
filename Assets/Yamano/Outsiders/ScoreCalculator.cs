using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

namespace LucKee
{

    //sss->100
    //ssl->110
    //sll->120
    //lll->130
    //~~~s->10n
    //~~~l->30n
    public class ScoreCalculator : MonoBehaviour
    {
        private static ScoreCalculator instance = null;
        private static ScoreCalculator Instance
        {
            get
            {
                //設定忘れ用
                if (instance == null)
                {
                    instance = new GameObject("ScoreCalculator").AddComponent<ScoreCalculator>();
                }
                return instance;
            }
        }

        //false:small
        //true:large
        //スコアの計算
        //ピースの大小とその順番、スコアボーナスの有無を受け取って計算する。
        //大小はtrueが大、falseが小となっている。
        //設定をしやすいようにMonoBehaviourを用いるが、計算以外を行わないためstaticでアクセスできるようにし、シングルトンの本体で計算するようにしている。
        public static int Calc(List<bool> sizes, bool bonus = false)
        {
            return Instance.CalcExecute(sizes, bonus);
        }

        //基礎スコア
        [SerializeField]
        private int baseScore = 100;

        //基礎スコアへの加算
        //繋げた最初の3つのうち、大きいピース1個につき1回加算される。
        [SerializeField]
        private int baseScorePerLarge = 10;

        //追加スコア(大)
        //4つ目以降のピースのうち、大きいピース1個につき1回加算される。
        [SerializeField]
        private int additionalScoreLarge = 30;

        //追加スコア(小)
        //4つ目以降のピースのうち、小さいピース1個につき1回加算される。
        [SerializeField]
        private int additionalScoreSmall = 10;

        //基礎ボーナス
        //スコアボーナスが発動している場合、基礎スコアと同様に加算される。
        [SerializeField]
        private int baseBonus = 10;

        //追加ボーナス
        //スコアボーナスが発動している場合、(大小問わず)4つ目以降のピース1個につき1回加算される。
        [SerializeField]
        private int additionalBonus = 5;

        //シングルトン用
        private void Awake()
        {
            instance = this;
        }

        //計算の本体
        //staticのメソッドからのみ呼ばれる。
        private int CalcExecute(List<bool> sizes, bool bonus)
        {
            //基礎スコアで初期化する。
            int score = baseScore;

            //スコアボーナス中なら同時にボーナスを加算する。
            if (bonus)
            {
                //基礎ボーナス
                score += baseBonus;

                //追加ボーナス
                score += (sizes.Count - 3) * additionalBonus;
            }

            //最初の3つのうち、大きいピースの数だけスコアを加算する。
            for (int i = 0; i < 3; i++)
            {
                if (sizes[i])
                {
                    score += baseScorePerLarge;
                }
            }

            //4つ目以降の計算
            for (int i = 3; i < sizes.Count; i++)
            {
                //サイズ判定
                if (sizes[i])
                {
                    //大
                    score += additionalScoreLarge;
                }
                else
                {
                    //小
                    score += additionalScoreSmall;
                }
            }
            //計算結果を返す。
            return score;
        }
    }
}