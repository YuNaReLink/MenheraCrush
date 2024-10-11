using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [System.Serializable]
    public struct PieceData
    {
        public Color32 color;
        public PieceTag pieceTag;
    };

    [CreateAssetMenu(fileName = "Piece", menuName = "CreatePieceData")]
    public class PieceDataList : ScriptableObject
    {
        [SerializeField]
        private List<PieceData> pieceDatas = new List<PieceData>();

        public List <PieceData> PieceDatas => pieceDatas;
    }
}


