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

    [SerializeField]
    Vector2[] offsets;

    [SerializeField]
    Button[] buttons;

    //ステージ変更
    void A(Stage StageNo)
    {
        int n = (int)StageNo;
        for (int i = 0; i < buttons.Length; i++)
        {
            Transform t = buttons[i].transform;
            int diff = n - i;
            int abs = Mathf.Abs(diff);

            if (abs >= offsets.Length)
            {
                buttons[i].enabled = false;
                continue;
            }

            buttons[i].enabled = true;

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
        NowStageNo++;

        if ((int)Stage.Stage3 < NowStageNo)
        {
            NowStageNo = (int)Stage.Stage3;
        }

        A((Stage)NowStageNo);
    }

    //左に送る
    public void Left()
    {
        NowStageNo--;

        if ((int)Stage.Stage1 > NowStageNo)
        {
            NowStageNo = (int)Stage.Stage1;
        }

        A((Stage)NowStageNo);
    }
}
