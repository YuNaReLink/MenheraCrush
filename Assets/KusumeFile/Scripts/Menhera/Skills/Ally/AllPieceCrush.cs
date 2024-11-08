using System.Collections.Generic;
using UnityEngine;

namespace Kusume 
{
    /// <summary>
    /// 味方メンヘラのスキルクラス
    /// 同じ色のピースを全て消すクラス
    /// </summary>
    public class AllPieceCrush : MonoBehaviour
    {
        private CreatePieceMachine      pieceMachine;

        public CreatePieceMachine       CreatePieceMachine => pieceMachine;

        private PieceInfo               pieceInfo;

        private LucKee.Skill            skill;


        private void Awake()
        {
            pieceMachine = FindObjectOfType<CreatePieceMachine>();
            skill = GetComponent<LucKee.Skill>();
        }

        private void Start()
        {
            GameController.Instance.SetPuzzleStop(true);

            List<Piece> pieceList = pieceMachine.Pieces;
            pieceInfo = pieceList[Random.Range(0, pieceList.Count)].PieceInfo;
        }

        private void Update()
        {
            Execute();
        }

        public void Execute()
        {
            List<Piece> pieceList = pieceMachine.Pieces;
            for (int i = 0; i < pieceList.Count; i++)
            {
                if (pieceInfo.color.tag != pieceList[i].PieceInfo.color.tag) { continue; }
                pieceList[i].Crush();
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
                skill.End();
            }
        }

        private void OnDestroy()
        {
            GameController.Instance.SetPuzzleStop(false);
        }
    }
}


