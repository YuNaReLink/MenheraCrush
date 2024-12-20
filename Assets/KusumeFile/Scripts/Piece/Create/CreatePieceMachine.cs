using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// �s�[�X�̃^�O
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
    /// �s�[�X�𐶐�����N���X
    /// </summary>
    public class CreatePieceMachine : MonoBehaviour
    {
        public static CreatePieceMachine Instance { get; private set; }

        /// <summary>
        /// �s�[�X�𐶐�����I�u�W�F�N�g�֌W�̕ϐ�
        /// </summary>
        [SerializeField]
        private List<Transform>         pieceSpawnPosition = new List<Transform>();

        private int                     creatorCount = 0;

        private int                     currentCreatorPositionCount = 0;

        [Header("�s�[�X�I�u�W�F�N�g���i�[����ScriptableObject")]
        [SerializeField]
        private PieceDataList           pieceData;

        [SerializeField]
        private PieceLedger             pieceLedger = null;
        public PieceLedger              PieceLedger => pieceLedger;

        [SerializeField]
        private Piece                   basePiece = null;

        [Header("�s�[�X���Ƃ̍ő�J�E���g")]
        [SerializeField]
        private int                     maxPieceCount = 100;

        [SerializeField]
        private List<Piece>             pieces = new List<Piece>();
        public List<Piece>              Pieces => pieces;
        /// <summary>
        /// �s�[�X�̐e�I�u�W�F�N�g
        /// </summary>
        [SerializeField]
        private PieceParent              piecesParent = null;
        /// <summary>
        /// �s�[�X�����̊Ԋu���Ƃ�ϐ�
        /// </summary>
        private float                   createCoolDown = 0f;

        [Header("�ύX����d�͔{��"), SerializeField]
        private float                   changeGravityScale;
        [Header("�ύX����(�b��)"), SerializeField]
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
        /// Update�ŌĂяo��
        /// </summary>
        private void Create()
        {
            if(Piece.Count >= maxPieceCount) { return; }
        
            //�s�[�X�̐���
            Piece p = Instantiate(basePiece, pieceSpawnPosition[currentCreatorPositionCount].position, Quaternion.identity); ;
            pieces.Add(p);
            Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 10.0f, ForceMode2D.Impulse);

            var pieceInfo = pieceLedger.GetRandomPiece();

            float scale = pieceInfo.size.size;

            p.transform.localScale *= scale;
            //�s�[�X�̐e��ݒ�
            p.transform.SetParent(piecesParent.transform);
            p.SetInit();
        
            Piece onePiece = p.GetComponent<Piece>();

            onePiece.SetPieceData(pieceInfo.color, pieceInfo);

            //�����ʒu��ύX
            currentCreatorPositionCount++;
            //�����ʒu�̍ő�l�ɒB������
            if (currentCreatorPositionCount >= creatorCount)
            {
                //0��
                currentCreatorPositionCount = 0;
            }
            //�����̃N�[���_�E��
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
