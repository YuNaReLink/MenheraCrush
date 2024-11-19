using System;
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
    [SerializeField] private Text comment;

    [SerializeField] private Image skillDetail;
    [SerializeField] private Image image;
    [SerializeField] private Image background;

    [SerializeField] private CharacterInfo[] infos;
    [SerializeField] private UnityEngine.UI.Button[] buttons;

    [SerializeField] private StageSelect changer;
    [SerializeField] private NowCharacter NC;

    public static int SelectCharacterNo {  get; private set; }


    private void Start()
    {
        name = GameObject.Find("Name").GetComponent<Text>();
        comment=GameObject.Find("SingleWord").GetComponent<Text>();

        skillDetail = GameObject.Find("CharacterDescription").GetComponent<Image>();
        image = GameObject.Find("CharacterImage").GetComponent<Image>();
        background = GameObject.Find("BaskImage").GetComponent<Image>();

        buttons[0] = GameObject.Find("HuzisakiAyane").GetComponent<Button>();
        buttons[1] = GameObject.Find("ShinonomeAoi").GetComponent<Button>();
        buttons[2] = GameObject.Find("HayashiKouta").GetComponent<Button>();
        buttons[3] = GameObject.Find("UenoNozomi").GetComponent<Button>();
        buttons[4] = GameObject.Find("SawashiroNozomi").GetComponent<Button>();

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
        name.text = infos[index].name;

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
            Sprite s = infos[i].yamiFace;
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
        background.color = infos[index].color;

        SelectCharacterNo = index;

        //キャラクター切替時の画像切替
        changer.ChangeCharacter();

        //メイン画面のキャラ表示変更
        NC.Change(index);
    }
}
