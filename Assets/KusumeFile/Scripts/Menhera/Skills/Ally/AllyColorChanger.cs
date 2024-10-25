using LucKee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class AllyColorChanger : MonoBehaviour, IColorChanger
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
            pieceInfo = pieceMachine.PieceLedger.GetRandomPiece();
            Piece p = pieceMachine.RandomPiece();
            PieceTag tag = p.Tag;
            for (int i = 0; i < pieceMachine.Pieces.Count; i++)
            {
                if (pieceMachine.Pieces[i].Tag != tag) { continue; }
                pieceMachine.Pieces[i].SetPieceData(pieceInfo.color,pieceInfo);
            }
        }
    }
}
