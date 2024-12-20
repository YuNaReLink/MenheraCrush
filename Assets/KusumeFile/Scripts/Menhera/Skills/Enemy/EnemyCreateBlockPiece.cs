using UnityEngine;

namespace Kusume
{
    public class Skill_EnemyCreateBlockPiece : MonoBehaviour, LucKee.ISkillObject
    {

        private PieceInfo               pieceInfo;

        [SerializeField]
        private int                     changeCount = 3;

        private void Awake()
        {
            pieceInfo = CreatePieceMachine.Instance.PieceLedger.GetDecisionPiece((int)PieceTag.Jama);
        }

        public void Execute()
        {
            for (int i = 0; i < changeCount; i++)
            {
                Create();
            }
        }

        private void Create()
        {
            Piece piece = CreatePieceMachine.Instance.Pieces[Random.Range(0, CreatePieceMachine.Instance.Pieces.Count - 1)];
            if (piece.IsSelected)
            {
                Create();
            }
            piece.SetPieceData(pieceInfo.color, pieceInfo);
        }
    }
}

