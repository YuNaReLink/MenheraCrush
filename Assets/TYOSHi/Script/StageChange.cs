using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Stage
{
    Null = -1,
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

    //�X�e�[�W�ύX
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

    //�E�ɑ���
    public void Right()
    {
        NowStageNo++;

        if((int)Stage.Count <= NowStageNo)
        {
            NowStageNo = 0;
        }

        MainBackImage.sprite= BackImages[NowStageNo];

        A((Stage)NowStageNo);
    }

    //���ɑ���
    public void Left()
    {
        NowStageNo--;

        if((int)Stage.Null >= NowStageNo)
        {
            NowStageNo = (int)Stage.Count - 1;
        }

        MainBackImage.sprite = BackImages[NowStageNo];

        A((Stage)NowStageNo);
    }

    public void ChangeCharacter()
    {
        //�I�𒆂̃L�����N�^�[�ɂ���ĉ摜�ύX
        Images[2].sprite= FourGroup[CharacterSwitching.SelctCharacterNo];
    }
}
