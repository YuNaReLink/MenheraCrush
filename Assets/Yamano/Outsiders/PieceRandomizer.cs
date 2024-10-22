using Kusume;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //ランダムな値の返却用構造体
    public struct PieceInfo
    {
        //色情報
        //TODO:Change type to tag.
        public int colorTag;

        //サイズ情報
        public SizeInfo size;
    }

    //[CreateAssetMenu(fileName = "PieceRandomizer", menuName = "ScriptableObjects/Randomizer/Piece", order = 1)]
    public class PieceRandomizer : ScriptableObject
    {
        [SerializeField]
        private ColorRandomizer colors;
        [SerializeField]
        private SizeRandomizer sizes;

        public PieceInfo GetRandom()
        {
            return new PieceInfo()
            {
                colorTag = colors.GetRandom(),
                size = sizes.GetRandom()
            };
        }
    }

}