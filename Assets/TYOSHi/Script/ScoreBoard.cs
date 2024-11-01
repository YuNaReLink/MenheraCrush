using Kusume;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private Text Score;

    void Start()
    {
        int value = Kusume.GameScore.Count;
        Score.text = String.Format("{0:#,0}", value);
    }
}
