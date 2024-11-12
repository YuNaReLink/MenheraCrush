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
    int index;

    [SerializeField] Vector2[] offsets;
    [SerializeField] Image[] images;
    [SerializeField] Sprite[] groups;
    [SerializeField] Sprite[] backSprite;
    [SerializeField] Image background;

    //ステージ変更
    void CheckState(StageNo no)
    {
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
    }

    //右に送る
    public void Right()
    {
        index++;

        if((int)StageNo.Count <= index)
        {
            index = 0;
        }

        background.sprite= backSprite[index];

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

        background.sprite = backSprite[index];

        CheckState((StageNo)index);
    }

    public void ChangeCharacter()
    {
        //選択中のキャラクターによって画像変更
        images[2].sprite= groups[CharacterSelect.SelectCharacterNo];
    }
}
