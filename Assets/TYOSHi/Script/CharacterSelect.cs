using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//�����G�֌W�Ȃ�
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
        //�L�������\��
        name.text = infos[index].name;

        //�L�����摜�ؑ�
        image.sprite = infos[index].fullBody;

        //�����e�L�X�g�ύX
        skillDetail.sprite = infos[index].skillDetail;

        //�ꌾ�e�L�X�g�ύX
        comment.text = infos[index].comment;

        //�������摜�ύX�ƐF�ύX
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

        //�L�����N�^�[�ؑ֎��̉摜�ؑ�
        changer.ChangeCharacter();

        //���C����ʂ̃L�����\���ύX
        NC.Change(index);
    }
}
