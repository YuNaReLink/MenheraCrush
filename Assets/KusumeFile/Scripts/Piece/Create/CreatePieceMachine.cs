using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// ピースのタグ
    /// </summary>
    public enum PieceTag
    {
        Red,
        Blue,
        Green,
        Yellow,
        Pink,
        Purple,
        Jama,
        Count
    }

    /// <summary>
    /// ピースを生成するクラス
    /// </summary>
    public class CreatePieceMachine : MonoBehaviour
    {
        /// <summary>
        /// ピースを生成するオブジェクト関係の変数
        /// </summary>
        [SerializeField]
        private List<Transform>         pieceSpawnPosition = new List<Transform>();

        private int                     creatorCount = 0;

        private int                     currentCreatorPositionCount = 0;

        [Header("ピースオブジェクトを格納したScriptableObject")]
        [SerializeField]
        private PieceDataList           pieceData = null;

        [SerializeField]
        private PieceLedger             pieceLedger = null;
        public PieceLedger              PieceLedger => pieceLedger;

        [SerializeField]
        private GameObject              basePiece = null;

        [Header("ピースごとの最大カウント")]
        [SerializeField]
        private int                     maxPieceCount = 100;

        private static int              currentPieceCount = 0;
        public static int               CurrentPieceCount { get { return currentPieceCount; }set { currentPieceCount = value; } }

        [SerializeField]
        private List<Piece>             pieces = new List<Piece>();
        public List<Piece>              Pieces => pieces;
        /// <summary>
        /// ピースの親オブジェクト
        /// </summary>
        [SerializeField]
        private GameObject              piecesParent = null;
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
            GameObject g = null;
            for(int i = 0; i < transform.childCount; i++)
            {
                g = transform.GetChild(i).gameObject;
                pieceSpawnPosition.Add(g.transform);
            }
            creatorCount = transform.childCount;
        }

        private void Start()
        {
            pieceLedger.Setup();
        }

        public Piece RandomPiece()
        {
            return pieces[Random.Range(0, pieces.Count + 1)];
        }

        void Update()
        {
            CheckAllPiece();

            if (GameController.Instance.IsPuzzleStop) { return; }

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
            if(currentPieceCount >= maxPieceCount) { return; }
        
            //ピースの生成
            GameObject g = Instantiate(basePiece, pieceSpawnPosition[currentCreatorPositionCount].position,Quaternion.identity);
            Piece p = g.GetComponent<Piece>();
            pieces.Add(p);
            Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 10.0f, ForceMode2D.Impulse);

            var pieceInfo = pieceLedger.GetRandomPiece();

            float scale = pieceInfo.size.size;

            p.transform.localScale *= scale;
            //ピースの親を設定
            p.transform.SetParent(piecesParent.transform);
        
            Piece onePiece = p.GetComponent<Piece>();

            onePiece.SetPieceData(pieceInfo.color, pieceInfo);

            //生成位置を変更
            currentCreatorPositionCount++;
            currentPieceCount++;
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
            if(currentPieceCount > pieces.Count) { return; }
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
