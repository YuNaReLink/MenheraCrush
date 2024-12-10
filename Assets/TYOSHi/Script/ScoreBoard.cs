using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    private LucKee.SpriteConverter  converter;
    [SerializeField]
    private Text                    resultText;

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
            resultText.text = "�����������������̓h�������I";
        }
        else
        {
            resultText.text = "YOU DIE";
        }
    }
}
