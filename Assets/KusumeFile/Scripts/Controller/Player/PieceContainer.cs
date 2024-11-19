using LucKee;
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
        private List<Piece>         pieceList = new List<Piece>();
        public List<Piece>          PieceList => pieceList;

        private CreatePieceMachine  createPiecemMachine;

        private PlayerHP            hp;
        public void Setup(PlayerController p)
        {
            createPiecemMachine = p.CreatePieceMachine;
            hp = p.HP;
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
                    //piece.SetSelected(false);
                    pieceList.RemoveAt(pieceList.Count - 1);
                    return;
                }
                //現在最後に連結したピースと今連結しようとしてるピースの差分を取得
                Vector2 dis = pieceList[pieceList.Count - 1].GetGameObject.transform.position - piece.GetGameObject.transform.position;
                //指定距離よりも遠かったらリターン
                if (dis.magnitude > MaxDisSetting(pieceList[pieceList.Count - 1], pieceList[pieceList.Count - 1].Tag))
                {
                    return;
                }
            }
            /*
             */
            if (pieceList.Count == 1)
            {
                //現在最後に連結したピースと今連結しようとしてるピースの差分を取得
                Vector2 d = pieceList[pieceList.Count-1].GetGameObject.transform.position - piece.GetGameObject.transform.position;
                //指定距離よりも遠かったらリターン
                if (d.magnitude > MaxDisSetting(pieceList[pieceList.Count-1], pieceList[pieceList.Count-1].Tag))
                {
                    return;
                }
            }
            for (int i = 0; i < pieceList.Count; i++)
            {
                if (pieceList[i] == piece ||
                   pieceList[0].Tag != piece.Tag) { return; }
            }
            //piece.SetSelected(true);
            pieceList.Add(piece);
        }

        public void CheckPieceList()
        {
            if(pieceList.Count <= 0) { return; }
            for (int i = 0;i < pieceList.Count; i++)
            {
                if (!pieceList[i].IsSelected)
                {
                    pieceList[i].SetSelected(true);
                }
            }
        }

        //ピースの連結間隔を決めてる関数(距離が気に入らないならここから変えろ)
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

                GameScore.SetOnceCount((int)ScoreCalculator.Calc(sizes, GameScore.Bonus));
                hp.Regain(5);
            }
            for(int i = 0;i < pieceList.Count; i++)
            {
                pieceList[i].SetSelected(false);
            }
            pieceList.Clear();
        }
    }
}
