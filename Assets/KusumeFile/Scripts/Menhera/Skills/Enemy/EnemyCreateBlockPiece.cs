using UnityEngine;

namespace Kusume
{
    public class Skill_EnemyCreateBlockPiece : MonoBehaviour
    {
        private CreatePieceMachine      pieceMachine;

        private PieceInfo               pieceInfo;

        [SerializeField]
        private int                     changeCount = 3;

        private void Awake()
        {
            pieceMachine = FindObjectOfType<CreatePieceMachine>();
            pieceInfo = pieceMachine.PieceLedger.GetDecisionPiece((int)PieceTag.Jama);
        }

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < changeCount; i++)
            {
                Create();
            }
        }

        private void Create()
        {
            Piece piece = pieceMachine.Pieces[Random.Range(0, pieceMachine.Pieces.Count - 1)];
            if (piece.IsSelected)
            {
                Create();
            }
            piece.SetPieceData(pieceInfo.color, pieceInfo);
        }
    }
}

