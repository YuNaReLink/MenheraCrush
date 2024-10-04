using UnityEngine;

/// <summary>
/// ピース単体のクラス
/// タグでピースを区別してる
/// </summary>
public class Piece : MonoBehaviour
{
    [SerializeField]
    private new PieceTag tag = PieceTag.Red;
    public PieceTag Tag { get { return tag; }set { tag = value; } }

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    public GameObject GetGameObject => transform.gameObject;

    [SerializeField]
    private GameObject impactObject = null;

    private float wait = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetPieceData(PieceData data)
    {
        tag = data.pieceTag;
        spriteRenderer.color = data.color;
    }
    private void Update()
    {
        if(wait <= 0)
        {
            return;
        }

        wait -= Time.deltaTime;

        if(wait <= 0)
        {
            Crush();
        }
    }

    public void Crush()
    {
        if (transform.localScale.x >= 1.5f)
        {
            Instantiate(impactObject, transform.position,Quaternion.identity);
        }
        CreatePiece.CurrentPieceCount--;
        Destroy(gameObject);
    }

    public void Crush(float w)
    {
        if(w <= 0)
        {
            Crush();
            return;
        }
        wait = w;
    }
}
