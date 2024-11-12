using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//味方敵関係なく
public enum CharacterNameList
{
    HuzisakiAyane,
    ShinonomeAoi,
    HayashiKouta,
    UenoNozomi,
    SawashiroNozomi,
    HanayaRaika,
    KuzuharaNaoya,
    Count
}
public class CharacterSelect : MonoBehaviour
{
    [SerializeField] private new Text name;
    [SerializeField] private Image skillDetail;
    [SerializeField] private Text comment;
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] fullSprites;
    [SerializeField] private Button[] buttons;
    [SerializeField] private Sprite[] normalFaceSprites;
    [SerializeField] private Sprite[] yamiFaceSprites;
    [SerializeField] private Sprite[] descriptions;
    [SerializeField] private TextLedger nameLedger;
    [SerializeField] private TextLedger commentLedger;
    [SerializeField] private Image background;
    [SerializeField] private Color[] backColor;


    [SerializeField] private StageSelect changer;

    public static int SelectCharacterNo {  get; private set; }


    private void Start()
    {
        Select((CharacterNameList)0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

    public void Select(CharacterNameList character)
    {
        int index = (int)character;
        //キャラ名表示
        name.text = nameLedger.GetText(index);

        //キャラ画像切替
        image.sprite = fullSprites[index];

        //説明テキスト変更
        skillDetail.sprite = descriptions[index];

        //一言テキスト変更
        comment.text = commentLedger.GetText(index);

        //ゆっくり画像変更と色変更
        for (int i=0;i< buttons.Length;i++)
        {
            Color c = Color.white;
            Sprite s = normalFaceSprites[i];
            if (i != (int)character)
            {
                c.r = 0.6f;
                c.g = 0.6f;
                c.b = 0.6f;
                s = yamiFaceSprites[i];
            }
            buttons[i].image.color = c;
            buttons[i].image.sprite = s;
        }
        background.color = backColor[index];

        SelectCharacterNo = index;

        //キャラクター切替時の画像切替
        changer.ChangeCharacter();
    }
}
