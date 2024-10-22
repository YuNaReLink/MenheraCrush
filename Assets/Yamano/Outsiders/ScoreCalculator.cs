using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{

    //sss->100
    //ssl->110
    //sll->120
    //lll->130
    //~~~s->10n
    //~~~l->30n
    public class ScoreCalculator
    {
        private static uint baseBonus = 10;
        private static uint additionalBonus = 5;


        //false:small
        //true:large
        public static uint Calc(List<bool> sizes, bool bonus = false)
        {
            uint score = 100;
            if (bonus)
            {
                score += baseBonus;
            }
            for (int i = 0; i < 3; i++)
            {
                if (sizes[i])
                {
                    score += 10;
                }
            }
            for (int i = 3; i < sizes.Count; i++)
            {
                if (sizes[i])
                {
                    score += 30;
                }
                else
                {
                    score += 10;
                }
                if (bonus)
                {
                    score += additionalBonus;
                }
            }
            return score;
        }
    }
}