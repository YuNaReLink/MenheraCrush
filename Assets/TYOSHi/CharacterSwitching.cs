using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterNameList
{
    //味方のみ
    藤崎綾音,
    東雲葵衣,
    林功太,
    キャラクター4,
    キャラクター5
}
public class CharacterSwitching : MonoBehaviour
{
    [SerializeField] private Text CharacterName;
    [SerializeField] private Text CharacterSkill;
    [SerializeField] private Image CharacterImage;
    [SerializeField] private Sprite[] sprites;


    public void Click(CharacterNameList GetName)
    {
        CharacterName.text = GetName.ToString();

        CharacterImage.sprite = sprites[(int)GetName];
    }
}
