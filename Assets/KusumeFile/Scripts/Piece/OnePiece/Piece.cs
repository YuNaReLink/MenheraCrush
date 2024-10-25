using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// ピース単体のクラス
    /// タグでピースを区別してる
    /// </summary>
    public class Piece : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rb2D; 
        public Rigidbody2D RB2D => rb2D;

        [SerializeField]
        private SpriteRenderer spriteRenderer = null;
        public GameObject GetGameObject => transform.gameObject;

        [SerializeField]
        private new PieceTag tag = PieceTag.Red;
        public PieceTag Tag { get { return tag; }set { tag = value; } }

        [Header("Scaleが1.5の時に使う爆発オブジェクト"),SerializeField]
        private GameObject impactObject = null;

        [SerializeField]
        private float keepImpactPower;
        public void SetImpactPower(float power) {  keepImpactPower = power; }

        private float wait = 0;

        private float noGravityCount = 0;
        public void SetNoGravityCount(float time) {  noGravityCount = time; }


        [SerializeField]
        private float baseGravityScale;

        private PieceInfo pieceInfo;
        public PieceInfo PieceInfo => pieceInfo;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            rb2D.gravityScale = baseGravityScale;
        }

        public void SetPieceData(ColorInfo data,PieceInfo _pieceInfo)
        {
            tag = data.tag;
            spriteRenderer.color = data.color;
            pieceInfo = _pieceInfo;
        }
        private void Update()
        {
            GravityUpdate();

            CrushUpdate();
        }

        private void GravityUpdate()
        {
            if (noGravityCount <= 0)
            {
                return;
            }

            noGravityCount -= Time.deltaTime;

            if (noGravityCount <= 0)
            {
                rb2D.gravityScale = baseGravityScale;
            }
        }

        private void CrushUpdate()
        {
            if (wait <= 0)
            {
                return;
            }

            wait -= Time.deltaTime;

            if (wait <= 0)
            {
                Crush();
            }
        }

        public void Crush()
        {
            if (transform.localScale.x >= 1.5f)
            {
                GameObject g = Instantiate(impactObject, transform.position,Quaternion.identity);
                g.transform.SetParent(transform.parent);
            }
            CreatePieceMachine.CurrentPieceCount--;
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

        private void OnTriggerStay(Collider other)
        {
            Piece piece = other.GetComponent<Piece>();
            if(piece == null) { return; }
            if(piece.transform.position.y < transform.position.y) { return; }
            if(keepImpactPower <= 0) { return; }

            Vector2 dir = piece.transform.position - transform.position;

            Rigidbody2D rb = piece.GetComponent<Rigidbody2D>();
            rb.AddForce(dir * keepImpactPower, ForceMode2D.Impulse);
            keepImpactPower *= 0.8f;
            piece.SetImpactPower(keepImpactPower);
            if(keepImpactPower <= 0)
            {
                keepImpactPower = 0;
            }
        }
    }
}
