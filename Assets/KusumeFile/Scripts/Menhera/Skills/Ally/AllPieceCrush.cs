using Kusume;
using System.Collections.Generic;
using UnityEngine;

public class AllPieceCrush : MonoBehaviour
{
    private CreatePieceMachine pieceMachine;

    public CreatePieceMachine CreatePieceMachine => pieceMachine;

    private PieceInfo pieceInfo;

    private LucKee.Skill skill;

    private void Awake()
    {
        pieceMachine = FindObjectOfType<CreatePieceMachine>();
        skill = GetComponent<LucKee.Skill>();
    }

    private void Start()
    {
        GameController.Instance.SetPuzzleStop(true);
        skill.SetSkillDestroyType(SkillDestroyType.SkillEnd);
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
            pieceList[i].Crush(0.1f * i);
        }
        if(pieceList.Count <= 0)
        {
            skill.SetEnd(true);
        }
    }

    private void OnDestroy()
    {
        GameController.Instance.SetPuzzleStop(false);
    }
}
