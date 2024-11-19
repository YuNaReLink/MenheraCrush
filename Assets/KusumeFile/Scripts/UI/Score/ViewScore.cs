using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class ViewScore : MonoBehaviour
    {
        private Text scoreText;

        private int subScore;

        private void Awake()
        {
            scoreText = GetComponent<Text>();
        }


        private void Start()
        {
            subScore = GameScore.Count;
            scoreText.text = String.Format("{0:0,########}", subScore);
        }


        private void Update()
        {
            if(subScore < GameScore.Count)
            {
                subScore += 10;
                scoreText.text = String.Format("{0:0,########}",subScore);
            }
        }
    }
}
