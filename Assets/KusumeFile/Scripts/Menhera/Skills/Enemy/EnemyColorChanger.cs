using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class EnemyColorChanger : MonoBehaviour, IColorChanger
    {
        private CreatePieceMachine pieceMachine;

        public CreatePieceMachine CreatePieceMachine => pieceMachine;

        [SerializeField]
        private ColorChangeType type = ColorChangeType.TypeAlly;

        public ColorChangeType Type => type;

        private PieceInfo pieceInfo;

        private void Awake()
        {
            pieceMachine = FindObjectOfType<CreatePieceMachine>();
        }

        private void Start()
        {
            Execute();
        }

        public void Execute()
        {
            List<Piece> pieceList = pieceMachine.Pieces;
            for (int i = 0; i < pieceList.Count; i++)
            {
                var pieceInfo = pieceMachine.PieceLedger.GetRandomPiece();
                pieceList[i].SetPieceData(pieceInfo.color);
            }
        }
    }
}
