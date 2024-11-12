using LucKee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    [SerializeField] private CharacterSelect select;
    [SerializeField] private CharacterNameList chara;
    public void Change()
    {
        //キャラ変更呼び出し
        select.Select(chara);
    }
}
