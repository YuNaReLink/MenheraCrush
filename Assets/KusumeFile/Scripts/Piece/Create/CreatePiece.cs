using System.Collections.Generic;
using UnityEngine;

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
    Purple
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

        p.transform.localScale *= Random.Range(1.0f, 1.5f);
        //�s�[�X�̐e��ݒ�
        p.transform.SetParent(piecesParent.transform);
        
        OnePiece onePiece = p.GetComponent<OnePiece>();

        PieceData data = pieceData.PieceDatas[PieceRandomNumber()];
        onePiece.PieceTag = data.pieceTag;
        onePiece.SpriteRenderer.color = data.color;

        //�����ʒu��ύX
        currentCreatorPositionCount++;
        //�����ʒu�̍ő�l�ɒB������
        if (currentCreatorPositionCount >= creatorCount)
        {
            //0��
            currentCreatorPositionCount = 0;
        }
        //�����̃N�[���_�E��
        createCoolDown = 0.1f;
    }

    private int PieceRandomNumber()
    {
        int num = 0;
        int min = (int)PieceTag.Red;
        int max = (int)PieceTag.Purple + 1;
        num = Random.Range(min, max);
        currentPieceCount++;
        return num;
    }
}
