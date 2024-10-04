using UnityEngine;

/// <summary>
/// ピースをまとめて動かす処理を行うクラス
/// ワールド座標で上方向と
/// ピースのローカル座標から右方向に動かす
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class WindSpace : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D boxCollider;

    [SerializeField]
    private float power = 500.0f;

    [SerializeField]
    private float duration = 1.0f;

    public void SetDuration(float _duration)
    {
        gameObject.SetActive(true);
        duration = _duration;
    }

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        boxCollider.isTrigger = true;
    }

    private void Update()
    {
        if(duration <= 0)
        {
            return;
        }
        duration -= Time.deltaTime;

        if(duration <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Piece piece = collision.GetComponent<Piece>();
        if(piece == null) { return; }
        Rigidbody2D rb = piece.GetComponent<Rigidbody2D>();
        if(rb == null) { return; }
        rb.AddForce(Vector2.up * power, ForceMode2D.Force);
        rb.AddForce(piece.transform.right * power, ForceMode2D.Force);
    }
}
