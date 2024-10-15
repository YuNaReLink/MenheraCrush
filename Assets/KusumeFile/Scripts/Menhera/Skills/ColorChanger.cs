using LucKee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public enum ColorChangeType
    {
        TypeAlly,
        TypeEnemy
    }
    public class ColorChanger : MonoBehaviour
    {
        private CreatePieceMachine pieceMachine;

        [SerializeField]
        private ColorChangeType type = ColorChangeType.TypeAlly;


        private PieceInfo pieceInfo;

        private void Awake()
        {
            pieceMachine = FindObjectOfType<CreatePieceMachine>();
            if(type == ColorChangeType.TypeAlly)
            {

            }
        }

        private void Start()
        {
            if (type == ColorChangeType.TypeAlly)
            {
                AllyExecute();
            }
            else
            {
                EnemyExecute();
            }
        }

        private void AllyExecute()
        {
            pieceInfo = pieceMachine.PieceLedger.GetRandomPiece();
            Piece p = pieceMachine.RandomPiece();
            PieceTag tag = p.Tag;
            for(int i = 0; i < pieceMachine.Pieces.Count; i++)
            {
                if(pieceMachine.Pieces[i].Tag != tag) { continue; }
                pieceMachine.Pieces[i].SetPieceData(pieceInfo.color);
            }
        }

        private void EnemyExecute()
        {
            List<Piece> pieceList = pieceMachine.Pieces;
            for(int i = 0; i < pieceList.Count; i++)
            {
                var pieceInfo = pieceMachine.PieceLedger.GetRandomPiece();
                pieceList[i].SetPieceData(pieceInfo.color);
            }
        }
    }
}
