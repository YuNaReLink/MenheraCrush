using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //テキストファイルの台帳
    //テキストファイルをSerializeFieldから追加することで使える。
    //ScriptableObjectを継承しているため、下記の1行のコメントアウトを解除することで使えるようになる。
    //[CreateAssetMenu(fileName = "TextLedger", menuName = "ScriptableObjects/TextLedger", order = 1)]
    public class TextLedger : LedgerBase<TextAsset>
    {

        //取得用メソッド
        //TextAsset型で使うことを想定していないため、単に文字列型で取得するようにしている。
        //配列の順番と添え字の対応に注意するべし。
        public string GetText(int i) { return Values[i].text; }
    }
}