using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class ViewScore : MonoBehaviour
    {

        private int subScore;

        private LucKee.SpriteConverter converter;

        private void Awake()
        {
            converter = GetComponent<LucKee.SpriteConverter>();
        }


        private void Start()
        {
            subScore = GameScore.Count;
            converter.SetText(string.Format("{0:0,########}", subScore));
        }


        private void Update()
        {
            if(subScore < GameScore.Count)
            {
                subScore += 10;
                converter.SetText(string.Format("{0:0,########}", subScore));
            }
        }
    }
}
