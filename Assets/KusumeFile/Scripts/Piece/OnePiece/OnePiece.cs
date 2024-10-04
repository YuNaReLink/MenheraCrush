using UnityEngine;

/// <summary>
/// �s�[�X�P�̂̃N���X
/// �^�O�Ńs�[�X����ʂ��Ă�
/// </summary>
public class OnePiece : MonoBehaviour
{
    [SerializeField]
    private PieceTag pieceTag = PieceTag.Red;
    public PieceTag PieceTag { get { return pieceTag; }set { pieceTag = value; } }

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;
    public SpriteRenderer SpriteRenderer => spriteRenderer;

    public GameObject GetGameObject => transform.gameObject;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        CreatePiece.CurrentPieceCount--;
    }
}
