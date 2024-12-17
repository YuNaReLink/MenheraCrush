using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// 味方メンヘラの同じ色のピースの色を変化させるスキルクラス
    /// </summary>
    public class AllyColorChanger : MonoBehaviour, IColorChanger,LucKee.ISkillObject
    {
        private CreatePieceMachine      pieceMachine;

        public CreatePieceMachine       CreatePieceMachine => pieceMachine;

        [SerializeField]
        private ColorChangeType         type = ColorChangeType.TypeAlly;

        public ColorChangeType          Type => type;

        private PieceInfo               pieceInfo;

        private void Awake()
        {
            pieceMachine = FindObjectOfType<CreatePieceMachine>();
        }

        public void Execute()
        {
            pieceInfo = pieceMachine.PieceLedger.GetRandomPiece();
            Piece p = pieceMachine.RandomPiece();
            PieceTag tag = p.Tag;
            for (int i = 0; i < pieceMachine.Pieces.Count; i++)
            {
                if (pieceMachine.Pieces[i].IsSelected) { continue; }
                if (pieceMachine.Pieces[i].Tag != tag) { continue; }
                pieceMachine.Pieces[i].Create();
                pieceMachine.Pieces[i].SetPieceData(pieceInfo.color,pieceInfo);
            }
        }
    }
}
