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
        Count
    }

    /// <summary>
    /// �s�[�X�𐶐�����N���X
    /// </summary>
    public class CreatePiece : MonoBehaviour
    {
        /// <summary>
        /// �s�[�X�𐶐�����I�u�W�F�N�g�֌W�̕ϐ�
        /// </summary>
        [SerializeField]
        private List<Transform> pieceSpawnPosition = new List<Transform>();

        private int creatorCount = 0;

        private int currentCreatorPositionCount = 0;

        [Header("�s�[�X�I�u�W�F�N�g���i�[����ScriptableObject")]
        [SerializeField]
        private PieceDataList pieceData = null;

        [SerializeField]
        private PieceLedger pieceLedger = null;

        [SerializeField]
        private GameObject basePiece = null;

        [Header("�s�[�X���Ƃ̍ő�J�E���g")]
        [SerializeField]
        private int maxPieceCount = 100;

        private static int currentPieceCount = 0;
        public static int CurrentPieceCount { get { return currentPieceCount; }set { currentPieceCount = value; } }
        /// <summary>
        /// �s�[�X�̐e�I�u�W�F�N�g
        /// </summary>
        [SerializeField]
        private GameObject piecesParent = null;
        /// <summary>
        /// �s�[�X�����̊Ԋu���Ƃ�ϐ�
        /// </summary>
        private float createCoolDown = 0f;

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

        void Update()
        {
            if(createCoolDown >= 0)
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
            GameObject p = Instantiate(basePiece, pieceSpawnPosition[currentCreatorPositionCount].position,Quaternion.identity);
            Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 25.0f, ForceMode2D.Impulse);

            var pieceInfo = pieceLedger.GetRandomPiece();

            float scale = pieceInfo.size.size;

            p.transform.localScale *= scale;
            //�s�[�X�̐e��ݒ�
            p.transform.SetParent(piecesParent.transform);
        
            Piece onePiece = p.GetComponent<Piece>();

            onePiece.SetPieceData(pieceInfo.color);

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
    }
}
