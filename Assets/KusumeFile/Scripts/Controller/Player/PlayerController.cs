using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class PlayerController : BaseMenheraController
    {
        [SerializeField]
        private bool                debug = false;

        private PlayerInput         playerInput = null;

        [SerializeField]
        private PlayerHP            hp;

        public PlayerHP             HP => hp;

        [SerializeField]
        private CreatePieceMachine  createPiecemMachine;
        public CreatePieceMachine CreatePieceMachine => createPiecemMachine;

        [SerializeField]
        private PieceContainer pieceContainer;
        public List<Piece> PieceList => pieceContainer.PieceList;

        protected override MenheraBoard Board => GameController.Instance.PlayerBoard;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            if (playerInput == null)
            {
                Debug.LogError("PlayerInputがアタッチされていません");
            }

            ViewHP viewHP = FindObjectOfType<ViewHP>();
            if(viewHP != null)
            {
                viewHP.Setup(this);
                hp.Setup();
            }
        }

        private void Start()
        {
            createPiecemMachine = FindObjectOfType<CreatePieceMachine>();
            if (createPiecemMachine == null)
            {
                Debug.LogError("CreatePieceMachineがアタッチされていません");
            }

            pieceContainer.Setup(this);
            SetCharaInt(CharacterSelect.SelectCharacterNo);
            SetMenheraUI();
        }
        /// <summary>
        /// デバッグ用のメソッド
        /// </summary>
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
            SetMenheraUI();

        }

        public void Update()
        {
            UpdateDebug();
            if (GameController.Instance.IsPuzzleStop||GameController.Instance.IsEndGame) { return; }

            if (Input.GetButtonDown("Jump"))
            {
                Instantiate(menheraData.Characters[charaInt].skill,transform.position,Quaternion.identity);
            }

            playerInput.ButtonInput();
            MouseRaycast();

            pieceContainer.CheckPieceList();
        }

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
                    hitObject = Physics2D.CircleCast(tapPoint, 0.3f, -Vector2.up);
                    //何にも当たっていなかったら
                    if (hitObject.collider == null) { return; }
                    onePiece = hitObject.collider.gameObject.GetComponent<Piece>();
                    //ピース情報がなかったらリターン
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
