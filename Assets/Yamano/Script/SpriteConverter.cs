using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LucKee
{
    //半角数字を全て絵文字に変換して表示するためのコンポーネント
    //絵文字対応のため、不本意ながらTextMeshProを用いて実装している。
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SpriteConverter : MonoBehaviour
    {
        /*
         * 各絵文字は名称で対応しており、下記の通りの条件で扱うことができる。
         * ・先に色を指定する。(Black及びPink)
         * ・後に文字を指定する。(各数字及びコンマ、コロン)
         * 例として、TextMeshProに<sprite name=Black0>と入力した場合、黒の0にあたる絵文字が表示される。
        */

        /*static*/

        //黒の絵文字
        private static readonly String Black = "Black";

        //ピンクの絵文字
        private static readonly String Pink = "Pink";

        //変換対象
        //変換する文字全てをひと繋ぎの文字列で保持している。
        private static readonly String Convertion = "0123456789,:";

        //絵文字を名称で呼び出すためのフォーマット
        //変数名をFormatとしたかったが、String.Formatとの混同を避けるために使用を控えた。
        private static readonly String Sentence = "<sprite name={0}>";

        /*Serialized*/

        //黒とピンクの切り替えを行うフラグ
        [SerializeField]
        private bool black = false;

        /*Component*/

        //対象のテキスト
        //今回の設計では同じオブジェクトに付いている。
        private TextMeshProUGUI mesh;

        /*Event*/

        private void Awake()
        {
            mesh = GetComponent<TextMeshProUGUI>();
            //For the test.
            //SetText("0123456789,:");
        }

        /*Method*/

        //文字列の変更
        //引数の文字列に含まれる数字を全てフォーマットに置き換えて変更する。
        public void SetText(String text)
        {
            //前に付く文字列の判断
            String title;
            if (black)
            {
                title = Black;
            }
            else
            {
                title = Pink;
            }

            for (int i = 0; i < Convertion.Length; i++)
            {
                //変換対象の文字
                String before = Convertion[i].ToString();

                //変換後の文字列
                String after = String.Format(Sentence, title + before);

                //各数字をフォーマットに従って置き換える。
                text = text.Replace(before, after);
            }

            //上記の処理後、対象のテキストに代入する。
            mesh.text = text;
        }

    }
}