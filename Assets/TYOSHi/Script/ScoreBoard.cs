using Kusume;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private Text score;

    private void Awake()
    {
        score = GetComponentInChildren<Text>();
    }
    void Start()
    {
        int value = Kusume.GameScore.Count;
        score.text = String.Format("{0:0,########}", value);
    }
}
