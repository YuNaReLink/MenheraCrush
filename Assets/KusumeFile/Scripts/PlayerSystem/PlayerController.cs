using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput = null;

    [SerializeField]
    private PlayerHP hp;

    public PlayerHP HP => hp;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        if (playerInput == null)
        {
            Debug.LogError("PlayerInputがアタッチされていません");
        }
    }

    private void Start()
    {
        hp.Setup();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            hp.Regain(10);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            hp.Decrease(10);
        }


        playerInput.ButtonInput();
        MouseRaycast();
    }
    /// <summary>
    /// 選択中のピースを保存するリスト
    /// </summary>
    [SerializeField]
    private List<Piece> pieceList = new List<Piece>();
    public List<Piece> PieceList=> pieceList;

    /// <summary>
    /// マウスクリック時にオブジェクトに当たってるか判定する関数
    /// </summary>
    private void MouseRaycast()
    {
        if (playerInput.LeftMouseButton)
        {
            var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                Piece onePiece;
                RaycastHit2D hitObject;
                //ピースの連結が1つ目なら
                if (pieceList.Count < 1)
                {
                    hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
                    onePiece = hitObject.collider.gameObject.GetComponent<Piece>();
                    if (onePiece == null) { return; }
                    if (!hitObject) { return; }
                }
                //ピースの連結が2つ目以降なら
                else
                {
                    //円のレイでピースと当たり判定
                    hitObject = Physics2D.CircleCast(tapPoint, 0.3f, -Vector2.up);
                    onePiece = hitObject.collider.gameObject.GetComponent<Piece>();
                    //ピース情報がなかったらリターン
                    if (onePiece == null) { return; }
                    //そもそも何にも当たっていなかったら
                    if (!hitObject) { return; }
                    //現在最後に連結したピースと今連結しようとしてるピースの差分を取得
                    Vector2 dis = pieceList[pieceList.Count - 1].GetGameObject.transform.position - onePiece.GetGameObject.transform.position;
                    //指定距離よりも遠かったらリターン
                    if(dis.magnitude > MaxDisSetting(pieceList[pieceList.Count - 1], pieceList[pieceList.Count - 1].Tag)) 
                    {
                        return;
                    }
                }
                if (onePiece == null) { return; }
                if (!hitObject) { return; }
                for (int i = 0; i < pieceList.Count; i++)
                {
                    if(pieceList[i] == onePiece||
                       pieceList[0].Tag != onePiece.Tag) { return; }
                }
                pieceList.Add(onePiece);
                Debug.Log("hit object is " + hitObject.collider.gameObject.name);
            }
        }
        else
        {
            if(pieceList.Count > 2)
            {
                for(int i = 0;i < pieceList.Count; i++)
                {
                    pieceList[i].Crush(0.05f * i);
                }
            }
            pieceList.Clear();
        }
    }

    //ピースの連結間隔を決めてる関数(距離が気に入らないならここから変えろ)
    private float MaxDisSetting(Piece piece,PieceTag tag)
    {
        float scale = piece.transform.localScale.x;
        float dis = 1.5f;
        if (scale == 1.5f)
        {
            dis = 2.0f;
        }
        else if (scale == 1.4f)
        {
            dis = 1.9f;
        }
        else if (scale == 1.3f)
        {
            dis = 1.8f;
        }
        else if (scale == 1.2f)
        {
            dis = 1.7f;
        }
        else if (scale == 1.1f)
        {
            dis = 1.6f;
        }
        else if (scale == 1.0f)
        {
            dis = 1.5f;
        }
        return dis;
    }
}
