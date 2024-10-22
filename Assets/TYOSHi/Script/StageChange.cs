using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Stage
{
    Stage1,
    Stage2,
    Stage3,

    Count
}

public class StageChange : MonoBehaviour
{
    int NowStageNo;

    [SerializeField] Vector2[] offsets;
    [SerializeField] Image[] Images;
    [SerializeField] Sprite[] FourGroup;
    [SerializeField] Sprite[] BackImages;
    [SerializeField] Image MainBackImage;

    //ステージ変更
    void A(Stage StageNo)
    {
        int n = (int)StageNo;
        for (int i = 0; i < Images.Length; i++)
        {
            Transform t = Images[i].transform;
            int diff = n - i;
            int abs = Mathf.Abs(diff);

            if (abs >= offsets.Length)
            {
                Images[i].enabled = false;
                continue;
            }

            Images[i].enabled = true;

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
        if((int)Stage.Stage3 <= NowStageNo)
        {
            return;
        }

        NowStageNo++;

        MainBackImage.sprite= BackImages[NowStageNo];

        A((Stage)NowStageNo);
    }

    //左に送る
    public void Left()
    {
        if((int)Stage.Stage1 >= NowStageNo)
        {
            return;
        }
        NowStageNo--;

        MainBackImage.sprite = BackImages[NowStageNo];

        A((Stage)NowStageNo);
    }

    public void ChangeCharacter()
    {
        //選択中のキャラクターによって画像変更
        Images[2].sprite= FourGroup[CharacterSwitching.SelctCharacterNo];
    }
}
