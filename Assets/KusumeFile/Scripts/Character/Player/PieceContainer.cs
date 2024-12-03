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

        private PlayerController controller;

        [SerializeField]
        private List<float> diss = new List<float>();
        public void Setup(PlayerController p)
        {
            controller = p;
            createPiecemMachine = p.CreatePieceMachine;
            hp = p.HP;
        }

        public void ChangePiece(Piece piece)
        {
            if(pieceList.Contains(piece)) 
            {
                if (pieceList.Count >= 2 && piece == pieceList[^2])
                {
                    //piece.SetSelected(false);
                    pieceList.RemoveAt(pieceList.Count - 1);
                }
                return; 
            }
            //piece.SetSelected(true);
            pieceList.Add(piece);
        }

        public bool CheckColor(PieceTag tag)
        {
            if(pieceList.Count <= 0)
            {
                return true;
            }
            return pieceList[0].Tag == tag;
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

        public void Crush()
        {
            if (pieceList.Count > 2)
            {
                List<bool> sizes = new List<bool>();

                createPiecemMachine.ChangeGravityAllPiece();
                for (int i = 0; i < pieceList.Count; i++)
                {
                    if((int)pieceList[0].PieceInfo.color.tag == controller.CharaInt)
                    {
                        pieceList[i].SetPlayerController(controller);
                        pieceList[i].AddSkillPoint(0.05f * i);
                    }
                    pieceList[i].Crush(0.05f * i);
                    sizes.Add(pieceList[i].PieceInfo.size.big);
                }
                GameScore.SetOnceCount((int)ScoreCalculator.Calc(sizes, GameScore.Bonus));
                PieceTag tag = pieceList[0].PieceInfo.color.tag;
                if (tag == PieceTag.Pink)
                {
                    hp.Regain(5);
                }
            }
            for(int i = 0;i < pieceList.Count; i++)
            {
                pieceList[i].SetSelected(false);
            }
            pieceList.Clear();
        }


        public Piece GetLastPiece()
        {
            if(pieceList.Count <= 0)
            {
                return null;
            }
            return pieceList[^1];
        }
    }
}
