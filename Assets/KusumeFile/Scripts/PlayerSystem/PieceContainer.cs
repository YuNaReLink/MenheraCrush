using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [System.Serializable]
    public class PieceContainer
    {
        /// <summary>
        /// 選択中のピースを保存するリスト
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
                //現在最後に連結したピースと今連結しようとしてるピースの差分を取得
                Vector2 dis = pieceList[pieceList.Count - 1].GetGameObject.transform.position - piece.GetGameObject.transform.position;
                //指定距離よりも遠かったらリターン
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

        //ピースの連結間隔を決めてる関数(距離が気に入らないならここから変えろ)
        private float MaxDisSetting(Piece piece, PieceTag tag)
        {
            float scale = piece.transform.localScale.x;
            float dis = 1.5f;
            if (scale < 1.3f)
            {
                dis = 1.25f;
            }
            else
            {
                dis = 1.5f;
            }
            return dis;
        }

        public void Crush()
        {
            if (pieceList.Count > 2)
            {
                createPiecemMachine.ChangeGravityAllPiece();
                for (int i = 0; i < pieceList.Count; i++)
                {
                    pieceList[i].Crush(0.05f * i);
                }
            }
            pieceList.Clear();
        }
    }
}
