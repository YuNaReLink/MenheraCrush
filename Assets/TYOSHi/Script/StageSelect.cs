using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum StageNo
{
    Null = -1,
    Stage1,
    Stage2,
    Stage3,

    Count
}

public class StageSelect : MonoBehaviour
{
    int index = (int)(StageNo)0;

    [SerializeField] Vector2[] offsets;
    [SerializeField] Image[] images;
    [SerializeField] Sprite[] groups;
    [SerializeField] Sprite[] backSprite;
    [SerializeField] Image background;

    [SerializeField] String[] stageName;
    [SerializeField] Text stageText;

    private void Awake()
    {
        background.sprite = backSprite[index];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }
    }

    //ステージ変更
    void CheckState(StageNo no)
    {
        background.sprite = backSprite[index];

        int n = (int)no;
        for (int i = 0; i < images.Length; i++)
        {
            Transform t = images[i].transform;
            int diff = n - i;
            int abs = Mathf.Abs(diff);

            if (abs >= offsets.Length)
            {
                images[i].enabled = false;
                continue;
            }

            images[i].enabled = true;

            t.localPosition = offsets[abs];

            if (diff > 0)
            {
                t.localPosition *= -1;
            }
        }

        stageText.text = stageName[(int)no];
    }

    //右に送る
    public void Right()
    {
        index++;

        if((int)StageNo.Count <= index)
        {
            index = 0;
        }

        CheckState((StageNo)index);
    }

    //左に送る
    public void Left()
    {
        index--;

        if((int)StageNo.Null >= index)
        {
            index = (int)StageNo.Count - 1;
        }

        CheckState((StageNo)index);
    }

    public void ChangeCharacter()
    {
        //選択中のキャラクターによって画像変更
        images[2].sprite = groups[CharacterSelect.SelectCharacterNo];
    }
}
