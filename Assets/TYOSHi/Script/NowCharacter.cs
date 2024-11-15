using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowCharacter : MonoBehaviour
{
    //���̐F
    [SerializeField] private Image buckColor;
    //�L����
    [SerializeField] private Image character;

    //�L�����̉摜����
    [SerializeField] private Sprite[] characters;

    //�C���[�W�J���[����
    [SerializeField] private Color[] characterColor;

    private void Awake()
    {
        //�����
        buckColor = GameObject.Find("BackColor").GetComponent<Image>();
        character =GameObject.Find("Chara").GetComponent<Image>();
    }

    public void Change(int Getcharacter)
    {
        //��������ϐ������Ăǂ��̂�����
        character.sprite = characters[Getcharacter];
        buckColor.color = characterColor[Getcharacter];
    }
}
