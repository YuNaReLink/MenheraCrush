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
            Debug.LogError("PlayerInput���A�^�b�`����Ă��܂���");
        }
    }

    public void Update()
    {
        playerInput.ButtonInput();
        MouseRaycast();
    }
    /// <summary>
    /// �I�𒆂̃s�[�X��ۑ����郊�X�g
    /// </summary>
    [SerializeField]
    private List<OnePiece> pieceList = new List<OnePiece>();
    public List<OnePiece> PieceList=> pieceList;

    /// <summary>
    /// �}�E�X�N���b�N���ɃI�u�W�F�N�g�ɓ������Ă邩���肷��֐�
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
                        Debug.Log("����������");
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

    //TODO : �s�[�X�̘A���Ԋu�����߂Ă�֐�(�������C�ɓ���Ȃ��Ȃ炱������ς���)
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
