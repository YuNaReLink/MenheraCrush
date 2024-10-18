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
    �A����Q,
    �V����
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
        //�L�������\��
        CharacterName.text = GetName.ToString();

        //�L�����摜�ؑ�
        CharacterImage.sprite = sprites[(int)GetName];

        //�������摜�ύX�ƐF�ύX
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
