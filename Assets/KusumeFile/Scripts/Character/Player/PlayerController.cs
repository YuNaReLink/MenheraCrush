using LucKee;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class PlayerController : BaseMenheraController
    {
        [SerializeField]
        private bool                    debug = false;

        private PlayerInput             playerInput = null;

        [SerializeField]
        private PlayerHP                hp;

        public PlayerHP                 HP => hp;

        [SerializeField]
        private float                   skillCoolDownCount = 1.0f;
        [SerializeField]
        private int                     skillRunCount = 0;

        [SerializeField]
        private int                     maxSkillRunCount = 0;   
        public void                     SetSkillRunCount(int count) 
        {
            skillRunCount += count;
            skillButton.MaskUpdate(skillRunCount, maxSkillRunCount);
            if(skillRunCount >= maxSkillRunCount)
            {
                skillRunCount = maxSkillRunCount;
                skillButton.SetStateButton(false);
            }
        }
        private Timer                   skillCoolTimer = new Timer(0);

        [SerializeField]
        private PieceContainer          pieceContainer;
        public PieceContainer           PieceContainer => pieceContainer;
        public List<Piece>              PieceList => pieceContainer.PieceList;

        protected override MenheraBoard board => GameController.Instance.PlayerBoard;

        public MenheraBoard Board => board;

        [SerializeField]
        private float minMag = 1.0f;
        [SerializeField]
        private float maxMag = 3.0f;

        SkillButton skillButton;

        private static int puzzleStop;
        public static int PuzzleStop => puzzleStop;
        public static void AddPuzzleStop() 
        {
            puzzleStop++; 
        }
        public static void DecPuzzleStop()
        {
            puzzleStop--;
        }

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
                hp.Setup(this);
            }

            SkillButton skill = FindObjectOfType<SkillButton>();
            if (skill != null)
            {
                skillButton = skill;
            }
        }

        private void Start()
        {

            pieceContainer.Setup(this);
            SetCharaInt(CharacterSelect.SelectCharacterNo);
            SetMenheraUI();
            skillButton.Setup(RunSkill);
            maxSkillRunCount = menheraData.Characters[charaInt].skillGauge;
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
                SetMenheraUI();
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                charaInt++;
                if(charaInt > (int)CharacterNameList.SawashiroNozomi)
                {
                    charaInt = (int)CharacterNameList.SawashiroNozomi;
                }
                SetMenheraUI();
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                skillRunCount = maxSkillRunCount;
            }
        }

        public void Update()
        {
            skillCoolTimer.Update(Time.deltaTime);

            UpdateDebug();
            if(puzzleStop > 0) { return; }
            if (!GameController.Instance.IsPlayable()) { return; }

            if (Input.GetButtonDown("Jump"))
            {
                RunSkill();
            }

            playerInput.ButtonInput();
            MouseRaycast();

            pieceContainer.CheckPieceList();
        }

        public void RunSkill()
        {
            if (skillRunCount < menheraData.Characters[charaInt].skillGauge) { return; }
            //カットイン
            CutIn c = skillButton.RunCutIn();
            //スキル
            Skill skill = Instantiate(menheraData.Characters[charaInt].skill, transform.position, Quaternion.identity);
            c.SetSkill(skill);
            skillCoolTimer.Start(skillCoolDownCount);
            skillRunCount = 0;
            skillButton.SetStateButton(true);
        }

        /// <summary>
        /// マウスクリック時にオブジェクトに当たってるか判定する関数
        /// </summary>
        private void MouseRaycast()
        {
            if (playerInput.LeftMouseButton)
            {
                //マウスの位置取得
                Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //最後に選択したピースの位置取得
                Piece last = pieceContainer.GetLastPiece();
                if(last != null)
                {
                    //最後のピースの位置取得
                    Vector2 lastPos = last.transform.position;
                    //マウス位置と最後のピースの距離を求める
                    Vector2 dis = tapPoint - lastPos;
                    //ベクトルの長さ
                    float mag = dis.magnitude;
                    //最低の長さよりも小さかったら無視
                    if(mag < minMag * last.transform.localScale.x) { return; }
                    //最大の長さよりも大きかったら
                    if(mag > maxMag * last.transform.localScale.x)
                    {
                        //位置を補正
                        tapPoint = lastPos + dis.normalized * maxMag * last.transform.localScale.x;
                    }
                }
                RaycastHit2D[] hitObjects;
                hitObjects = Physics2D.CircleCastAll(tapPoint, 0.01f, Vector2.zero, 0.01f);
                foreach (RaycastHit2D hitObject in hitObjects)
                {
                    Piece piece = hitObject.collider.gameObject.GetComponent<Piece>();
                    //ピース情報がなかったらリターン
                    if (piece == null) { continue; }
                    if (!pieceContainer.CheckColor(piece.Tag)) { continue; }
                    pieceContainer.ChangePiece(piece);
                }
            }
            else
            {
                pieceContainer.Crush();
            }
        }
    }

}
