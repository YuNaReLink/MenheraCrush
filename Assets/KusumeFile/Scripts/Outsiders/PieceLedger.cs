using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Kusume
{
    [Serializable]
    public struct ColorInfo
    {
        //TODO:Change type to enum.
        public PieceTag tag;
        public Color32 color;
        public float ratio;
    }
    [Serializable]
    public struct SizeInfo
    {
        public float size;
        public float power;
        public float ratio;
        public bool big;
    }
    public struct PieceInfo
    {
        public ColorInfo color;
        public SizeInfo size;
    }

    [CreateAssetMenu(fileName = "PieceLedger", menuName = "ScriptableObjects/PieceLedger", order = 1)]
    public class PieceLedger : ScriptableObject
    {
        [SerializeField]
        private ColorInfo[] colors;
        [SerializeField]
        private SizeInfo[] sizes;
        private float sum_color = 0;
        private float sum_size = 0;

        private Unity.Mathematics.Random random = new Unity.Mathematics.Random();

        public void Setup()
        {
            random = new Unity.Mathematics.Random((uint)System.DateTime.Now.Ticks);
        }

        private void Initialize()
        {
            sum_color = 0;
            sum_size = 0;
            foreach (ColorInfo color in colors)
            {
                sum_color += color.ratio;
            }
            foreach (SizeInfo size in sizes)
            {
                sum_size += size.ratio;
            }
        }

        public PieceInfo GetRandomPiece()
        {
            if (sum_color <= 0)
            {
                Initialize();
            }
            PieceInfo info = new PieceInfo();
            int colorIndex = GetRandomColor();
            if (colorIndex < 0)
            {
                return info;
            }
            int sizeIndex = GetRandomSize();
            if (sizeIndex < 0)
            {
                return info;
            }
            info.color = colors[colorIndex];
            info.size = sizes[sizeIndex];
            return info;
        }
        public int GetRandomColor()
        {
            float randomized = random.NextFloat() * sum_color;
            for (int i = 0; i < colors.Length; i++)
            {
                randomized -= colors[i].ratio;
                if (randomized <= 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public int GetRandomSize()
        {
            float randomized = random.NextFloat() * sum_size;
            for (int i = 0; i < sizes.Length; i++)
            {
                randomized -= sizes[i].ratio;
                if (randomized <= 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }

}

