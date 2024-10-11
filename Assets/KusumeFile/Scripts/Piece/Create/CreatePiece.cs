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
    Purple,
    Count
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

    private enum ScaleTag
    {
        Lv0,
        Lv1,
        DataEnd
    }

    /// <summary>
    /// Updateで呼び出し
    /// </summary>
    private void Create()
    {
        if(currentPieceCount >= maxPieceCount) { return; }
        
        //ピースの生成
        GameObject p = Instantiate(basePiece, pieceSpawnPosition[currentCreatorPositionCount].position,Quaternion.identity);
        Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * 25.0f, ForceMode2D.Impulse);

        int tagNum = Random.Range((int)ScaleTag.Lv0, (int)ScaleTag.DataEnd);

        ScaleTag tag = (ScaleTag)tagNum;
        float scale = 1.0f;
        switch (tag)
        {
            case ScaleTag.Lv0:
                scale = 1.25f;
                break;
            case ScaleTag.Lv1:
                scale = 1.5f;
                break;
        }

        p.transform.localScale *= scale;
        //ピースの親を設定
        p.transform.SetParent(piecesParent.transform);
        
        Piece onePiece = p.GetComponent<Piece>();

        PieceData data = pieceData.PieceDatas[PieceRandomNumber()];
        onePiece.SetPieceData(data);

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
        int max = (int)PieceTag.Count;
        num = Random.Range(min, max);
        currentPieceCount++;
        return num;
    }
}
