using LucKee;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
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
    PlayebleCount,
    HanayaRaika = PlayebleCount,
    KuzuharaNaoya,
    Count
}
public class CharacterSelect : MonoBehaviour
{
    private new RubiedName name;
    private Text comment;

    private Image skillDetail;
    private Image image;
    private Image background;

    [SerializeField] private CharacterInfo[] infos;
    private UnityEngine.UI.Button[] buttons = new Button[(int)CharacterNameList.PlayebleCount];

    [SerializeField] private StageSelect changer;
    [SerializeField] private NowCharacter NC;

    public static int SelectCharacterNo {  get; private set; }


    private void Start()
    {
        name = GameObject.Find("RubiedName").GetComponent<RubiedName>();
        comment=GameObject.Find("SingleWord").GetComponent<Text>();

        skillDetail = GameObject.Find("CharacterDescription").GetComponent<Image>();
        image = GameObject.Find("CharacterImage").GetComponent<Image>();
        background = GameObject.Find("BaskImage").GetComponent<Image>();

        buttons[0] = GameObject.Find("HuzisakiAyane").GetComponent<Button>();
        buttons[1] = GameObject.Find("ShinonomeAoi").GetComponent<Button>();
        buttons[2] = GameObject.Find("HayashiKouta").GetComponent<Button>();
        buttons[3] = GameObject.Find("SawashiroNozomi").GetComponent<Button>();
        buttons[4] = GameObject.Find("UenoNozomi").GetComponent<Button>();

        Select((CharacterNameList)SelectCharacterNo);
        gameObject.SetActive(false);
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
        name.SetName(infos[index].name);

        //キャラ画像切替
        image.sprite = infos[index].fullBody;

        //説明テキスト変更
        skillDetail.sprite = infos[index].skillDetail;

        //一言テキスト変更
        comment.text = infos[index].comment;

        //ゆっくり画像変更と色変更
        for (int i=0;i< buttons.Length;i++)
        {
            Color c = Color.white;
            Sprite s = infos[i].normalFace;
            if (i != (int)character)
            {
                c.r = 0.6f;
                c.g = 0.6f;
                c.b = 0.6f;
                s = infos[i].yamiFace;
            }
            buttons[i].image.color = c;
            buttons[i].image.sprite = s;
        }
        background.sprite= infos[index].backImage;

        SelectCharacterNo = index;

        //キャラクター切替時の画像切替
        changer.ChangeCharacter();

        //メイン画面のキャラ表示変更
        NC.Change(index);
    }
}
