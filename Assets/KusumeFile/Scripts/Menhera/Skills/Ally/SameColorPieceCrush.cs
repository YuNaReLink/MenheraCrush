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

        private PieceInfo               pieceInfo;

        private PieceTag                pieceTag;

        private List<bool>              sizes = new List<bool>();

        private PlayerController controller;

        private void Awake()
        {
            controller = FindObjectOfType<PlayerController>();
        }

        private void Start()
        {
            GameController.Instance.SetPuzzleState(PuzzleState.Stop);

            List<Piece> pieceList = CreatePieceMachine.Instance.Pieces;
            /*
            int index = Random.Range(0, pieceList.Count);
            pieceInfo = pieceList[index].PieceInfo;
             */

            List<PieceTag> pieceTags = new();
            int[] count = Piece.PieceTagCount;
            for(int i = 0; i < count.Length;i++)
            {
                if (count[i] == 0) { continue; }
                pieceTags.Add((PieceTag)i);
            }

            int index = Random.Range(0, pieceTags.Count);
            pieceTag = pieceTags[index];
        }

        public void Execute()
        {
            List<Piece> pieceList = CreatePieceMachine.Instance.Pieces;
            for (int i = 0; i < pieceList.Count; i++)
            {
                //決めたピースの
                if (pieceTag != pieceList[i].Tag) { continue; }
                if (pieceTag == PieceTag.Red)
                {
                    pieceList[i].SetPlayerController(controller);
                    pieceList[i].AddSkillPoint(0);
                }
                pieceList[i].Crush();
                sizes.Add(pieceList[i].PieceInfo.size.big);
            }
            /*
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
            */
            GameController.Instance.SetPuzzleState(PuzzleState.Playable);
        }
    }
}


