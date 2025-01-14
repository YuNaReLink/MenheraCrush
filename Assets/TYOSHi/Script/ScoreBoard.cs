using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    private LucKee.SpriteConverter  converter;

    [SerializeField]
    private Image                   resultImage;
    [SerializeField]
    private Image                   backGround;

    [SerializeField]
    private Sprite                  clearResult;
    [SerializeField]
    private Sprite                  overResult;

    [SerializeField]
    private Sprite[]                resultSprites;

    [SerializeField]
    private Sprite[]                backSprites;

    private void Awake()
    {
        converter = GetComponentInChildren<LucKee.SpriteConverter>();
        
    }
    void Start()
    {
        int value = Kusume.GameScore.Count;
        converter.SetText(String.Format("{0:0,########}", value));

        if (Kusume.GameScore.IsSuccessful())
        {
            resultImage.sprite = resultSprites[0];
            backGround.sprite = backSprites[0];
        }
        else
        {
            resultImage.sprite = resultSprites[1];
            backGround.sprite = backSprites[1];
        }
    }
}
