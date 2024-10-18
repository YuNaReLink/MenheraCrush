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
    植野美浪,
    澤城希美
}
public class CharacterSwitching : MonoBehaviour
{
    [SerializeField] private Text CharacterName;
    [SerializeField] private Text CharacterSkill;
    [SerializeField] private Image CharacterImage;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Button[] Buttons;
    [SerializeField] private Sprite[] NormalFaceSprites;
    [SerializeField] private Sprite[] YamiFaceSprites;

    private void Start()
    {
        Select((CharacterNameList)0);
    }


    public void Select(CharacterNameList GetName)
    {
        //キャラ名表示
        CharacterName.text = GetName.ToString();

        //キャラ画像切替
        CharacterImage.sprite = sprites[(int)GetName];

        //ゆっくり画像変更と色変更
        for(int i=0;i< Buttons.Length;i++)
        {
            Color c = Color.white;
            Sprite s = NormalFaceSprites[i];
            if (i != (int)GetName)
            {
                c.r = 0.6f;
                c.g = 0.6f;
                c.b = 0.6f;
                s = YamiFaceSprites[i];
            }
            Buttons[i].image.color = c;
            Buttons[i].image.sprite = s;
        }
    }
}
