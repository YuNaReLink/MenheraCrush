using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private bool debug = false;

        private PlayerInput playerInput = null;

        [SerializeField]
        private PlayerHP hp;

        public PlayerHP HP => hp;

        [SerializeField]
        private Image thisImage;
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private CreatePieceMachine createPiecemMachine;

        [SerializeField]
        private AllyData allyData;
        [SerializeField]
        private int charaInt = 0;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            if (playerInput == null)
            {
                Debug.LogError("PlayerInput���A�^�b�`����Ă��܂���");
            }

            createPiecemMachine = FindObjectOfType<CreatePieceMachine>();
            if(createPiecemMachine == null)
            {
                Debug.LogError("CreatePieceMachine���A�^�b�`����Ă��܂���");
            }

        }

        private void Start()
        {
            pieceContainer.Setup(createPiecemMachine);

            charaInt = CharacterSwitching.SelctCharacterNo;
            SetAllyImage();
            hp.Setup();
        }

        private void SetAllyImage()
        {
            animator.runtimeAnimatorController = allyData.Characters[charaInt].animator;
            thisImage.sprite = allyData.Characters[charaInt].sprite;
            thisImage.SetNativeSize();
        }

        private void UpdateDebug()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                debug = !debug;
            }
            if (!debug) { return; }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                charaInt--;
                if (charaInt < 0)
                {
                    charaInt = 0;
                }
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                charaInt++;
                if(charaInt > (int)CharacterNameList.SawashiroNozomi)
                {
                    charaInt = (int)CharacterNameList.SawashiroNozomi;
                }
            }
            SetAllyImage();

        }

        public void Update()
        {
            UpdateDebug();
            if (GameController.Instance.IsPuzzleStop) { return; }

            if (Input.GetButtonDown("Jump"))
            {
                Instantiate(allyData.Characters[charaInt].skill,transform.position,Quaternion.identity);
            }

            playerInput.ButtonInput();
            MouseRaycast();
        }

        [SerializeField]
        private PieceContainer pieceContainer;
        public List<Piece> PieceList => pieceContainer.PieceList;

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
                    hitObject = Physics2D.CircleCast(tapPoint, 0.3f, -Vector2.up);
                    //���ɂ��������Ă��Ȃ�������
                    if (hitObject.collider == null) { return; }
                    onePiece = hitObject.collider.gameObject.GetComponent<Piece>();
                    //�s�[�X��񂪂Ȃ������烊�^�[��
                    if (onePiece == null) { return; }
                    pieceContainer.ChangePiece(onePiece);
                }
            }
            else
            {
                pieceContainer.Crush();
            }
        }
    }

}
