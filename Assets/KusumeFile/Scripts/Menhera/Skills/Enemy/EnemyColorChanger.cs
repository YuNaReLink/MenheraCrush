using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// 敵メンヘラのスキルクラス
    /// 全ピースの色をランダムに変化させるクラス
    /// </summary>
    public class EnemyColorChanger : MonoBehaviour, IColorChanger
    {

        [SerializeField]
        private ColorChangeType         type = ColorChangeType.TypeAlly;

        public ColorChangeType          Type => type;

        private PieceInfo               pieceInfo;

        private void Start()
        {
            Execute();
        }

        public void Execute()
        {
            List<Piece> pieceList = CreatePieceMachine.Instance.Pieces;
            for (int i = 0; i < pieceList.Count; i++)
            {
                if (pieceList[i].IsSelected) { continue; }
                var pieceInfo = CreatePieceMachine.Instance.PieceLedger.GetRandomPiece();
                pieceList[i].Create();
                pieceList[i].SetPieceData(pieceInfo.color, pieceInfo);
            }
        }
    }
}
