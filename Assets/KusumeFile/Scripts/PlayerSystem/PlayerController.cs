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
            Debug.LogError("PlayerInput���A�^�b�`����Ă��܂���");
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
    /// �I�𒆂̃s�[�X��ۑ����郊�X�g
    /// </summary>
    [SerializeField]
    private List<Piece> pieceList = new List<Piece>();
    public List<Piece> PieceList=> pieceList;

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
                Piece onePiece;
                RaycastHit2D hitObject;
                //�s�[�X�̘A����1�ڂȂ�
                if (pieceList.Count < 1)
                {
                    hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
                    onePiece = hitObject.collider.gameObject.GetComponent<Piece>();
                    if (onePiece == null) { return; }
                    if (!hitObject) { return; }
                }
                //�s�[�X�̘A����2�ڈȍ~�Ȃ�
                else
                {
                    //�~�̃��C�Ńs�[�X�Ɠ����蔻��
                    hitObject = Physics2D.CircleCast(tapPoint, 0.3f, -Vector2.up);
                    onePiece = hitObject.collider.gameObject.GetComponent<Piece>();
                    //�s�[�X��񂪂Ȃ������烊�^�[��
                    if (onePiece == null) { return; }
                    //�����������ɂ��������Ă��Ȃ�������
                    if (!hitObject) { return; }
                    //���ݍŌ�ɘA�������s�[�X�ƍ��A�����悤�Ƃ��Ă�s�[�X�̍������擾
                    Vector2 dis = pieceList[pieceList.Count - 1].GetGameObject.transform.position - onePiece.GetGameObject.transform.position;
                    //�w�苗���������������烊�^�[��
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

    //�s�[�X�̘A���Ԋu�����߂Ă�֐�(�������C�ɓ���Ȃ��Ȃ炱������ς���)
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
