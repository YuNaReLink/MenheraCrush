using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterNameList
{
    //味方のみ
    HuzisakiAyane,
    ShinonomeAoi,
    HayashiKouta,
    UenoNozomi,
    SawashiroNozomi,

    Count
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
    [SerializeField] private TextLedger Text;
    [SerializeField] private Image BackImage;

    [SerializeField] private StageChange SC;

    public static int SelctCharacterNo {  get; private set; }


    private void Start()
    {
        Select((CharacterNameList)0);
    }

    public void Select(CharacterNameList GetName)
    {
        //キャラ名表示
        CharacterName.text = Text.GetText((int)GetName);

        //キャラ画像切替
        CharacterImage.sprite = sprites[(int)GetName];

        //説明テキスト変更
        CharacterSkill.text = Text.GetText((int)GetName+5);

        //ゆっくり画像変更と色変更
        for (int i=0;i< Buttons.Length;i++)
        {
            Color c = Color.white;
            Color bc = Color.white;
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

            //背景色変更
            switch((int)GetName)
            {
                case (int)CharacterNameList.HuzisakiAyane:
                    bc = new Color(0.5843138f, 0.5372549f, 0.682353f,1.0f);
                    break;
                case (int)CharacterNameList.ShinonomeAoi:
                    bc = new Color(0.1921569f, 0.2862745f, 0.4196079f,1.0f);
                    break;
                case (int)CharacterNameList.HayashiKouta:
                    bc = new Color(0.5019608f, 0.6980392f, 0.5176471f,1.0f);
                    break;
                case (int)CharacterNameList.UenoNozomi:
                    bc = new Color(0.7254902f, 0.6392157f,0.4f,1.0f);
                    break;
                case (int)CharacterNameList.SawashiroNozomi:
                    bc = new Color(0.682353f, 0.3803922f, 0.372549f,1.0f);
                    break;
            }
            BackImage.color = bc;
        }

        SelctCharacterNo = (int)GetName;

        //キャラクター切替時の画像切替
        SC.ChangeCharacter();
    }
}
