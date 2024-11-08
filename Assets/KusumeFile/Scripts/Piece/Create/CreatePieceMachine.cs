using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// �s�[�X�̃^�O
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
    /// �s�[�X�𐶐�����N���X
    /// </summary>
    public class CreatePieceMachine : MonoBehaviour
    {
        /// <summary>
        /// �s�[�X�𐶐�����I�u�W�F�N�g�֌W�̕ϐ�
        /// </summary>
        [SerializeField]
        private List<Transform>         pieceSpawnPosition = new List<Transform>();

        private int                     creatorCount = 0;

        private int                     currentCreatorPositionCount = 0;

        [Header("�s�[�X�I�u�W�F�N�g���i�[����ScriptableObject")]
        [SerializeField]
        private PieceDataList           pieceData = null;

        [SerializeField]
        private PieceLedger             pieceLedger = null;
        public PieceLedger              PieceLedger => pieceLedger;

        [SerializeField]
        private GameObject              basePiece = null;

        [Header("�s�[�X���Ƃ̍ő�J�E���g")]
        [SerializeField]
        private int                     maxPieceCount = 100;

        private static int              currentPieceCount = 0;
        public static int               CurrentPieceCount { get { return currentPieceCount; }set { currentPieceCount = value; } }

        [SerializeField]
        private List<Piece>             pieces = new List<Piece>();
        public List<Piece>              Pieces => pieces;
        /// <summary>
        /// �s�[�X�̐e�I�u�W�F�N�g
        /// </summary>
        [SerializeField]
        private GameObject              piecesParent = null;
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
        /// Update�ŌĂяo��
        /// </summary>
        private void Create()
        {
            if(currentPieceCount >= maxPieceCount) { return; }
        
            //�s�[�X�̐���
            GameObject g = Instantiate(basePiece, pieceSpawnPosition[currentCreatorPositionCount].position,Quaternion.identity);
            Piece p = g.GetComponent<Piece>();
            pieces.Add(p);
            Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 10.0f, ForceMode2D.Impulse);

            var pieceInfo = pieceLedger.GetRandomPiece();

            float scale = pieceInfo.size.size;

            p.transform.localScale *= scale;
            //�s�[�X�̐e��ݒ�
            p.transform.SetParent(piecesParent.transform);
        
            Piece onePiece = p.GetComponent<Piece>();

            onePiece.SetPieceData(pieceInfo.color, pieceInfo);

            //�����ʒu��ύX
            currentCreatorPositionCount++;
            currentPieceCount++;
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
