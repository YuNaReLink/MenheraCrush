using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// ピースをまとめて動かす処理を行うクラス
    /// ワールド座標で上方向と
    /// ピースのローカル座標から右方向に動かす
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]
    public class WindSpace : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider2D   boxCollider;

        [SerializeField]
        private float           power = 500.0f;

        [SerializeField]
        private float           duration = 1.0f;
        public float            Duration => duration;

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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Piece piece = collision.GetComponent<Piece>();
            if (piece == null) { return; }

            Rigidbody2D rb = piece.GetComponent<Rigidbody2D>();
            if (rb == null) { return; }

            Vector2 v = Vector2.zero;
            float random = Random.Range(-1.0f, 1.0f);
            float angle = 60.0f * random;
            angle += 90.0f;
            angle *= Mathf.Deg2Rad;
            v.x = Mathf.Cos(angle);
            v.y = Mathf.Sin(angle);
            Vector2 position = (Vector2)piece.transform.position + new Vector2(0.5f * random * piece.transform.localScale.x, 0);
            rb.AddForceAtPosition(v * power,position,ForceMode2D.Force);
            Debug.Log(random);
        }
    }
}
