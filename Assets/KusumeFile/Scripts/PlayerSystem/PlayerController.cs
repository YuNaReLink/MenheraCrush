using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput = null;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        if(playerInput == null)
        {
            Debug.LogError("PlayerInputがアタッチされていません");
        }
    }

    public void Update()
    {
        playerInput.ButtonInput();
        MouseRaycast();
    }
    /// <summary>
    /// 選択中のピースを保存するリスト
    /// </summary>
    [SerializeField]
    private List<OnePiece> pieceList = new List<OnePiece>();
    public List<OnePiece> PieceList=> pieceList;

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
                OnePiece onePiece;
                RaycastHit2D hitObject;
                if (pieceList.Count < 1)
                {
                    hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
                    onePiece = hitObject.collider.gameObject.GetComponent<OnePiece>();
                    if (onePiece == null) { return; }
                    if (!hitObject) { return; }
                }
                else
                {
                    hitObject = Physics2D.CircleCast(tapPoint, 0.3f, -Vector2.up);
                    onePiece = hitObject.collider.gameObject.GetComponent<OnePiece>();
                    if (onePiece == null) { return; }
                    if (!hitObject) { return; }
                    Vector2 dis = pieceList[pieceList.Count - 1].GetGameObject.transform.position - onePiece.GetGameObject.transform.position;
                    if(dis.magnitude > MaxDisSetting(pieceList[0].PieceTag)) 
                    {
                        Debug.Log("距離が遠い");
                        return; 
                    }
                }
                if (onePiece == null) { return; }
                if (!hitObject) { return; }
                for (int i = 0; i < pieceList.Count; i++)
                {
                    if(pieceList[i] == onePiece||
                       pieceList[0].PieceTag != onePiece.PieceTag) { return; }
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
                    Destroy(pieceList[i].GetGameObject,0.05f * i);
                }
            }
            pieceList.Clear();
        }
    }

    //TODO : ピースの連結間隔を決めてる関数(距離が気に入らないならここから変えろ)
    private float MaxDisSetting(PieceTag tag)
    {
        float dis = 1.0f;
        switch (tag)
        {
            case PieceTag.Red:
                dis = 1.5f;
                break;
            case PieceTag.Blue:
                dis = 2.0f;
                break;
            case PieceTag.Green:
                dis = 1.5f;
                break;
            case PieceTag.Yellow:
                dis = 1.5f;
                break;
            case PieceTag.Pink:
                dis = 1.5f;
                break;
            case PieceTag.Purple:
                dis = 1.5f;
                break;
        }
        return dis;
    }
}
