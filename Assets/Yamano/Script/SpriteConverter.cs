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
        /*Serialized*/

        //フォーマット
        //{0}の部分に絵文字の番号が入ることになる。
        //0~9……ピンク色
        //10~19……黒色
        //黒色を使いたい場合は{0}の直前に'1'を書き足して10番台にするべし。
        [SerializeField]
        private String format = "<sprite index={0}>";

        /*Component*/

        //対象のテキスト
        //今回の設計では同じオブジェクトに付いている。
        private TextMeshProUGUI mesh;

        /*Event*/

        private void Awake()
        {
            mesh = GetComponent<TextMeshProUGUI>();
        }

        /*Method*/

        //文字列の変更
        //引数の文字列に含まれる数字を全てフォーマットに置き換えて変更する。
        public void SetText(String text)
        {
            //数字は10種類だけなので固定値で行う。
            for (int i = 0; i < 10; i++)
            {
                //各数字をフォーマットに従って置き換える。
                text = text.Replace(i.ToString(), String.Format(format, i));
            }

            //上記の処理後、対象のテキストに代入する。
            mesh.text = text;
        }

    }
}