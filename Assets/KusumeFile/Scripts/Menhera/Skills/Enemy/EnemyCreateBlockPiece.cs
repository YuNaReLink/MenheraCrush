using Kusume;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_EnemyCreateBlockPiece : MonoBehaviour
{
    private CreatePieceMachine pieceMachine;

    public CreatePieceMachine CreatePieceMachine => pieceMachine;

    private PieceInfo pieceInfo;

    private void Awake()
    {
        pieceMachine = FindObjectOfType<CreatePieceMachine>();
        pieceInfo = pieceMachine.PieceLedger.GetDecisionPiece((int)PieceTag.Jama);
    }

    // Start is called before the first frame update
    void Start()
    {
        Piece piece = pieceMachine.Pieces[Random.Range(0, pieceMachine.Pieces.Count - 1)];
        piece.SetPieceData(pieceInfo.color, pieceInfo);
    }
}
