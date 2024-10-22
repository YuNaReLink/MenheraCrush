using Kusume;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    //�����_���Ȓl�̕ԋp�p�\����
    public struct PieceInfo
    {
        //�F���
        //TODO:Change type to tag.
        public int colorTag;

        //�T�C�Y���
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