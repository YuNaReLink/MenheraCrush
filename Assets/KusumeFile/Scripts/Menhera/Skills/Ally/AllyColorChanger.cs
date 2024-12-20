using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// 味方メンヘラの同じ色のピースの色を変化させるスキルクラス
    /// </summary>
    public class AllyColorChanger : MonoBehaviour, IColorChanger,LucKee.ISkillObject
    {

        [SerializeField]
        private ColorChangeType         type = ColorChangeType.TypeAlly;

        public ColorChangeType          Type => type;

        private PieceInfo               pieceInfo;


        public void Execute()
        {
            pieceInfo = CreatePieceMachine.Instance.PieceLedger.GetRandomPiece();
            Piece p = CreatePieceMachine.Instance.RandomPiece();
            PieceTag tag = p.Tag;
            for (int i = 0; i < CreatePieceMachine.Instance.Pieces.Count; i++)
            {
                if (CreatePieceMachine.Instance.Pieces[i].IsSelected) { continue; }
                if (CreatePieceMachine.Instance.Pieces[i].Tag != tag) { continue; }
                CreatePieceMachine.Instance.Pieces[i].Create();
                CreatePieceMachine.Instance.Pieces[i].SetPieceData(pieceInfo.color,pieceInfo);
            }
        }
    }
}
