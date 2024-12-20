using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// �G�����w���̃X�L���N���X
    /// �S�s�[�X�̐F�������_���ɕω�������N���X
    /// </summary>
    public class EnemyColorChanger : MonoBehaviour, IColorChanger
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

        private void Start()
        {
            Execute();
        }

        public void Execute()
        {
            List<Piece> pieceList = pieceMachine.Pieces;
            for (int i = 0; i < pieceList.Count; i++)
            {
                if (pieceList[i].IsSelected) { continue; }
                var pieceInfo = pieceMachine.PieceLedger.GetRandomPiece();
                pieceList[i].Create();
                pieceList[i].SetPieceData(pieceInfo.color, pieceInfo);
            }
        }
    }
}
