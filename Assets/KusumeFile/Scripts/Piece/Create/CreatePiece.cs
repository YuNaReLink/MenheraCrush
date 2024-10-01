using System.Collections.Generic;
using UnityEngine;

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
    Purple
}

/// <summary>
/// ピースを生成するクラス
/// </summary>
public class CreatePiece : MonoBehaviour
{
    /// <summary>
    /// ピースを生成するオブジェクト関係の変数
    /// </summary>
    [SerializeField]
    private List<Transform> pieceSpawnPosition = new List<Transform>();

    private int creatorCount = 0;

    private int currentCreatorPositionCount = 0;

    [Header("ピースオブジェクトを格納したScriptableObject")]
    [SerializeField]
    private PieceDataList pieceData = null;

    [SerializeField]
    private GameObject basePiece = null;

    [Header("ピースごとの最大カウント")]
    [SerializeField]
    private int maxPieceCount = 100;

    private static int currentPieceCount = 0;
    public static int CurrentPieceCount { get { return currentPieceCount; }set { currentPieceCount = value; } }
    /// <summary>
    /// ピースの親オブジェクト
    /// </summary>
    [SerializeField]
    private GameObject piecesParent = null;
    /// <summary>
    /// ピース生成の間隔をとる変数
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
    /// Updateで呼び出し
    /// </summary>
    private void Create()
    {
        if(currentPieceCount >= maxPieceCount) { return; }
        
        //ピースの生成
        GameObject p = Instantiate(basePiece, pieceSpawnPosition[currentCreatorPositionCount].position,Quaternion.identity);

        p.transform.localScale *= Random.Range(1.0f, 1.5f);
        //ピースの親を設定
        p.transform.SetParent(piecesParent.transform);
        
        OnePiece onePiece = p.GetComponent<OnePiece>();

        PieceData data = pieceData.PieceDatas[PieceRandomNumber()];
        onePiece.PieceTag = data.pieceTag;
        onePiece.SpriteRenderer.color = data.color;

        //生成位置を変更
        currentCreatorPositionCount++;
        //生成位置の最大値に達したら
        if (currentCreatorPositionCount >= creatorCount)
        {
            //0に
            currentCreatorPositionCount = 0;
        }
        //生成のクールダウン
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
