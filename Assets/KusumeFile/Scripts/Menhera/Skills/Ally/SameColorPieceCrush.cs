using System.Collections.Generic;
using UnityEngine;

namespace Kusume 
{
    /// <summary>
    /// 味方メンヘラのスキルクラス
    /// 同じ色のピースを全て消すクラス
    /// </summary>
    public class SameColorPieceCrush : MonoBehaviour, LucKee.ISkillObject
    {
        private CreatePieceMachine      pieceMachine;

        public CreatePieceMachine       CreatePieceMachine => pieceMachine;

        private PieceInfo               pieceInfo;

        private List<bool>              sizes = new List<bool>();

        private void Awake()
        {
            pieceMachine = FindObjectOfType<CreatePieceMachine>();
        }

        private void Start()
        {
            GameController.Instance.SetPuzzleStop(true);

            List<Piece> pieceList = pieceMachine.Pieces;
            pieceInfo = pieceList[Random.Range(0, pieceList.Count)].PieceInfo;
        }

        public void Execute()
        {
            List<Piece> pieceList = pieceMachine.Pieces;
            for (int i = 0; i < pieceList.Count; i++)
            {
                if (pieceInfo.color.tag != pieceList[i].PieceInfo.color.tag) { continue; }
                pieceList[i].Crush();
                sizes.Add(pieceList[i].PieceInfo.size.big);
                pieceList.RemoveAt(i);
            }
            int num = 0;
            for (int i = 0; i < pieceList.Count; i++)
            {
                if (pieceInfo.color.tag == pieceList[i].PieceInfo.color.tag)
                {
                    num++;
                }
            }
            if (num <= 0)
            {
                GameScore.SetOnceCount((int)LucKee.ScoreCalculator.Calc(sizes, GameScore.Bonus));
            }
            GameController.Instance.SetPuzzleStop(false);
        }
    }
}


