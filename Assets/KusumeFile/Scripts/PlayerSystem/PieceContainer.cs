using LucKee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [System.Serializable]
    public class PieceContainer
    {
        /// <summary>
        /// �I�𒆂̃s�[�X��ۑ����郊�X�g
        /// </summary>
        [SerializeField]
        private List<Piece> pieceList = new List<Piece>();
        public List<Piece> PieceList => pieceList;

        private CreatePieceMachine createPiecemMachine;
        public void Setup(CreatePieceMachine c)
        {
            createPiecemMachine = c;
        }

        public void ChangePiece(Piece piece)
        {
            if(pieceList.Count > 1)
            {
                if(piece == pieceList[pieceList.Count - 1])
                {
                    return;
                }
                if(pieceList.Count >= 2&&piece == pieceList[pieceList.Count - 2])
                {
                    pieceList.RemoveAt(pieceList.Count - 1);
                    return;
                }
                //���ݍŌ�ɘA�������s�[�X�ƍ��A�����悤�Ƃ��Ă�s�[�X�̍������擾
                Vector2 dis = pieceList[pieceList.Count - 1].GetGameObject.transform.position - piece.GetGameObject.transform.position;
                //�w�苗���������������烊�^�[��
                if (dis.magnitude > MaxDisSetting(pieceList[pieceList.Count - 1], pieceList[pieceList.Count - 1].Tag))
                {
                    return;
                }
            }
            for (int i = 0; i < pieceList.Count; i++)
            {
                if (pieceList[i] == piece ||
                   pieceList[0].Tag != piece.Tag) { return; }
            }
            pieceList.Add(piece);
        }

        //�s�[�X�̘A���Ԋu�����߂Ă�֐�(�������C�ɓ���Ȃ��Ȃ炱������ς���)
        private float MaxDisSetting(Piece piece, PieceTag tag)
        {
            float scale = piece.transform.localScale.x;
            float dis = 1.5f;
            if (scale < 1.3f)
            {
                dis = 2.0f;
            }
            else
            {
                dis = 2.0f;
            }
            return dis;
        }

        public void Crush()
        {
            if (pieceList.Count > 2)
            {
                List<bool> sizes = new List<bool>();

                createPiecemMachine.ChangeGravityAllPiece();
                for (int i = 0; i < pieceList.Count; i++)
                {
                    pieceList[i].Crush(0.05f * i);
                    sizes.Add(pieceList[i].PieceInfo.size.big);
                }
                //TODO : �{�[�i�X�ύX
                GameScore.SetOnceCount((int)ScoreCalculator.Calc(sizes, GameScore.Bonus));
            }
            pieceList.Clear();
        }
    }
}
