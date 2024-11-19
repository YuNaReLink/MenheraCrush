using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowCharacter : MonoBehaviour
{
    //後ろの色
    [SerializeField] private Image buckColor;
    //キャラ
    [SerializeField] private Image character;

    //キャラの画像たち
    [SerializeField] private Sprite[] characters;

    //イメージカラーたち
    [SerializeField] private Color[] characterColor;

    private void Awake()
    {
        //代入の
        buckColor = GameObject.Find("BackColor").GetComponent<Image>();
        character =GameObject.Find("Chara").GetComponent<Image>();
    }

    public void Change(int Getcharacter)
    {
        //もらった変数を入れてどうのこうの
        character.sprite = characters[Getcharacter];
        buckColor.color = characterColor[Getcharacter];
    }
}
