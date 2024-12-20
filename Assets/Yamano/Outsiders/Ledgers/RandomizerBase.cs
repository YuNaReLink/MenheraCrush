using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace LucKee
{
    [Serializable]
    public struct RandomUnit<T>
    {
        public T value;
        public float ratio;
    }
    //[CreateAssetMenu(fileName = "__Randomizer", menuName = "ScriptableObjects/Randomizer/__", order = 1)]
    public abstract class RandomizerBase<T> : LedgerBase<RandomUnit<T>>
    {
        private static System.Random random = new();
        private float sum = 0.0f;
        private void Initialize()
        {
            sum = 0.0f;
            foreach (RandomUnit<T> unit in Values)
            {
                sum += unit.ratio;
            }
        }
        public T GetRandom()
        {
            if (Values.Length <= 1)
            {
                if (Values.Length <= 0)
                {
                    throw new Exception("There are nothing to return.");
                }
                return Values[0].value;
            }
            if (sum <= 0.0f)
            {
                Initialize();
            }
            float r = (float)random.NextDouble() * sum;
            for (int i = 0; i < Values.Length; i++)
            {
                r -= Values[i].ratio;
                if (r <= 0.0f)
                {
                    return Values[i].value;
                }
            }
            throw new Exception("Something went wrong at Randomizer!");
        }
    }
}