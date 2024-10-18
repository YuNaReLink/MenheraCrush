using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterNameList
{
    //�����̂�
    ���舻��,
    ���_����,
    �ь���,
    �L�����N�^�[4,
    �L�����N�^�[5
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
