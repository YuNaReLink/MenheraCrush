using System;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    private LucKee.SpriteConverter converter;

    private void Awake()
    {
        converter = GetComponentInChildren<LucKee.SpriteConverter>();
    }
    void Start()
    {
        int value = Kusume.GameScore.Count;
        converter.SetText(String.Format("{0:0,########}", value));
    }
}
