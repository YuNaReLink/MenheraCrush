using UnityEngine;

/// <summary>
/// �s�[�X���m���Ȃ����Ă邱�Ƃ�������悤�ɂ��邾���̃N���X
/// </summary>
public class PieceConcatenate : MonoBehaviour
{
    [SerializeField]
    private GameObject lineGameObject = null;
    [SerializeField]
    private LineRenderer lineRenderer = null;   

    private PlayerController playerController = null;

    private void Awake()
    {
        if(lineGameObject != null)
        {
            lineRenderer = lineGameObject.GetComponent<LineRenderer>();
        }

        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        LineConcatenate();
    }

    private void LineConcatenate()
    {
        lineRenderer.positionCount = playerController.PieceList.Count;
        if (playerController.PieceList.Count <= 0) { return; }
        for(int i = 0; i < playerController.PieceList.Count; i++)
        {
            lineRenderer.SetPosition(i,playerController.PieceList[i].GetGameObject.transform.position);
        }
    }
}
