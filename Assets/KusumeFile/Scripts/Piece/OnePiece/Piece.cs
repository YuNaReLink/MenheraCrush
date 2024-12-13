using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// ピース単体のクラス
    /// タグでピースを区別してる
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Piece : MonoBehaviour
    {
        LucKee.SEManager seManager;

        [SerializeField]
        private Rigidbody2D         rb2D; 
        public Rigidbody2D          RB2D => rb2D;

        [SerializeField]
        private SpriteRenderer      spriteRenderer = null;

        [SerializeField]
        private Material            mat = null;
        public GameObject           GetGameObject => transform.gameObject;

        [SerializeField]
        private new PieceTag        tag = PieceTag.Red;
        public PieceTag             Tag { get { return tag; }set { tag = value; } }

        [Header("ピースサイズが大の時に使う爆発オブジェクト")]
        [SerializeField]
        private ImpactObject        impactObject = null;

        [SerializeField]
        private float               keepImpactPower;
        public void                 SetImpactPower(float power) {  keepImpactPower = power; }

        private float               crushWait = 0;

        private float               addSkillpointWait = 0;   

        private float               noGravityCount = 0;
        public void                 SetNoGravityCount(float time) {  noGravityCount = time; }


        [SerializeField]
        private float               baseGravityScale;

        private PieceInfo           pieceInfo;
        public PieceInfo            PieceInfo => pieceInfo;

        [SerializeField]
        private bool selected = false;
        public bool IsSelected => selected;


        [SerializeField]
        private ParticleSystem breakEffect;
        [SerializeField]
        private Sprite breakSprite;

        public void Create()
        {
            GameObject effect = Instantiate(breakEffect.gameObject, transform.position,Quaternion.identity);
            ParticleSystem particleSystem = effect.GetComponent<ParticleSystem>();
            var renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
            // 現在のマテリアルを取得
            Material material = renderer.material;
            material.mainTexture = breakSprite.texture;
        }

        private PlayerController player;
        public void SetPlayerController(PlayerController controller) { player = controller; }
        public void SetSelected(bool s) 
        {
            if(selected != s)
            {
                selected = s; 
            }
        }

        public void SetInit()
        {
            PieceParent pieceParent = GetComponentInParent<PieceParent>();
            seManager = pieceParent.gameObject.GetComponent<LucKee.SEManager>();
        }

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            rb2D.gravityScale = baseGravityScale;
            if (spriteRenderer != null)
            {
                mat = spriteRenderer.material;
            }
        }

        

        public void SetPieceData(ColorInfo data,PieceInfo _pieceInfo)
        {
            tag = data.tag;
            //spriteRenderer.color = data.color;
            pieceInfo = _pieceInfo;
            spriteRenderer.sprite = data.sprite;
            spriteRenderer.material = data.material;

            //effectColor = data.color;

            breakSprite = data.breakSprite;
        }
        private void Update()
        {
            GravityUpdate();

            CrushUpdate();

            AddSkillPointUpdate();
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
            if (crushWait <= 0)
            {
                return;
            }

            crushWait -= Time.deltaTime;

            if (crushWait <= 0)
            {
                Crush();
            }
        }

        private void AddSkillPointUpdate()
        {
            if(addSkillpointWait <= 0)
            {
                return;
            }

            addSkillpointWait -= Time.deltaTime;

            if(addSkillpointWait <= 0)
            {
                AddSkillCount();
            }
        }

        public void Crush()
        {
            if (transform.localScale.x >= 1.5f)
            {
                GameObject g = Instantiate(impactObject.gameObject, transform.position,Quaternion.identity);
                g.transform.SetParent(transform.parent);
                seManager.Play(0);
            }
            else
            {
                seManager.Play(1);
            }
            CreatePieceMachine.CurrentPieceCount--;
            Create();
            Destroy(gameObject);
        }

        public void Crush(float w)
        {
            if(crushWait > 0) { return; }
            if(w <= 0)
            {
                Crush();
                return;
            }
            crushWait = w;
        }

        public void AddSkillPoint(float w)
        {
            if (addSkillpointWait > 0) { return; }
            if (w <= 0)
            {
                AddSkillCount();
                return;
            }
            addSkillpointWait = w;
        }

        private void AddSkillCount()
        {
            player.SetSkillRunCount(1);
        }

        private void OnTriggerStay(Collider other)
        {
            Piece piece = other.GetComponent<Piece>();
            if(piece == null) { return; }
            if(piece.transform.position.y < transform.position.y) { return; }
            if(keepImpactPower <= 0) { return; }
            //ピースを削除した時の爆発処理
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
