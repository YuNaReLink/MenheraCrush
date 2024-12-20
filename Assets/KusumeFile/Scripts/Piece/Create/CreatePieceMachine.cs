using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// ピースのタグ
    /// </summary>
    public enum PieceTag
    {
        Null = -1,
        Purple,
        Blue,
        Green,
        Red,
        Yellow,
        Pink,
        Jama,
        Count
    }

    /// <summary>
    /// ピースを生成するクラス
    /// </summary>
    public class CreatePieceMachine : MonoBehaviour
    {
        public static CreatePieceMachine Instance { get; private set; }

        /// <summary>
        /// ピースを生成するオブジェクト関係の変数
        /// </summary>
        [SerializeField]
        private List<Transform>         pieceSpawnPosition = new List<Transform>();

        private int                     creatorCount = 0;

        private int                     currentCreatorPositionCount = 0;

        [Header("ピースオブジェクトを格納したScriptableObject")]
        [SerializeField]
        private PieceDataList           pieceData;

        [SerializeField]
        private PieceLedger             pieceLedger = null;
        public PieceLedger              PieceLedger => pieceLedger;

        [SerializeField]
        private Piece                   basePiece = null;

        [Header("ピースごとの最大カウント")]
        [SerializeField]
        private int                     maxPieceCount = 100;

        [SerializeField]
        private List<Piece>             pieces = new List<Piece>();
        public List<Piece>              Pieces => pieces;
        /// <summary>
        /// ピースの親オブジェクト
        /// </summary>
        [SerializeField]
        private PieceParent              piecesParent = null;
        /// <summary>
        /// ピース生成の間隔をとる変数
        /// </summary>
        private float                   createCoolDown = 0f;

        [Header("変更する重力倍率"), SerializeField]
        private float                   changeGravityScale;
        [Header("変更時間(秒数)"), SerializeField]
        private float                   noGravityCount;
        private void Awake()
        {
            Instance = this;

            GameObject g = null;
            for(int i = 0; i < transform.childCount; i++)
            {
                g = transform.GetChild(i).gameObject;
                pieceSpawnPosition.Add(g.transform);
            }
            creatorCount = transform.childCount;

            piecesParent = FindObjectOfType<PieceParent>();
        }

        private void Start()
        {
            pieceLedger.Setup();
        }

        public Piece RandomPiece()
        {
            return pieces[Random.Range(0, pieces.Count)];
        }

        void Update()
        {
            CheckAllPiece();

            if (!GameController.Instance.IsPlayable()) { return; }

            if (createCoolDown >= 0)
            {
                createCoolDown -= Time.deltaTime;
                return;
            }
            Create();
        }

        /// <summary>
        /// Updateで呼び出し
        /// </summary>
        private void Create()
        {
            if(Piece.Count >= maxPieceCount) { return; }
        
            //ピースの生成
            Piece p = Instantiate(basePiece, pieceSpawnPosition[currentCreatorPositionCount].position, Quaternion.identity); ;
            pieces.Add(p);
            Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 10.0f, ForceMode2D.Impulse);

            var pieceInfo = pieceLedger.GetRandomPiece();

            float scale = pieceInfo.size.size;

            p.transform.localScale *= scale;
            //ピースの親を設定
            p.transform.SetParent(piecesParent.transform);
            p.SetInit();
        
            Piece onePiece = p.GetComponent<Piece>();

            onePiece.SetPieceData(pieceInfo.color, pieceInfo);

            //生成位置を変更
            currentCreatorPositionCount++;
            //生成位置の最大値に達したら
            if (currentCreatorPositionCount >= creatorCount)
            {
                //0に
                currentCreatorPositionCount = 0;
            }
            //生成のクールダウン
            createCoolDown = 0;
        }

        private void CheckAllPiece()
        {
            if(Piece.Count > pieces.Count) { return; }
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i] == null)
                {
                    PieceRemove(i);
                }
            }
        }

        public void PieceRemove(int num)
        {
            pieces.RemoveAt(num);
        }

        public void ChangeGravityAllPiece()
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                Piece piece = pieces[i].GetComponent<Piece>();
                Rigidbody2D rb = piece.GetComponent<Rigidbody2D>();
                rb.gravityScale = changeGravityScale;
                piece.SetNoGravityCount(noGravityCount);
            }
        }
    }
}
