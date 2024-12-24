using UnityEngine;

namespace Kusume
{
    public enum PuzzleState
    {
        Playable,
        Stop,
        End
    }
    public class GameController : MonoBehaviour
    {

        private static GameController   instance;
        public static GameController    Instance => instance;

        private Timer                   gameTimer;
        public Timer                    GameTimer => gameTimer;
        [SerializeField]
        private float                   gameTimerCount = 10.0f;

        [SerializeField]
        private GamePreparationData     preparationData;

        [SerializeField]
        private MenheraBoard            player;
        public MenheraBoard             PlayerBoard => player;
        [SerializeField]
        private MenheraBoard            enemy;
        public MenheraBoard             EnemyBoard => enemy;

        [SerializeField]
        private AudioClip bgm;

        [SerializeField]
        private MenheraData allyData;
        [SerializeField]
        private MenheraData enemyData;
        public MenheraData EnemyData => enemyData;
        private CharacterInfo enemyDataInfo;
        public CharacterInfo EnemyDataInfo => enemyDataInfo;

        private CharacterInfo allyDataInfo;
        public CharacterInfo AllyDataInfo => allyDataInfo;

        private AllyBackSpriteRenderer allyBack;

        private GameStarter gameStarter;

        public void SetPreparation()
        {
            //準備時の用意するオブジェクトを作成
            preparationData.Datas.Instantiate();
        }
        private PuzzleState             state;
        public PuzzleState              State => state;
        public void SetPuzzleState(PuzzleState s) {  state = s; }
        public bool IsPlayable() { return state == PuzzleState.Playable && Time.timeScale > 0; }

        public void EndGame() 
        {
            state = PuzzleState.End;
            resultSystem.Create();
        }

        private ResultSystem resultSystem;

        private void Awake()
        {
            SetupInstance();
            gameTimer = new Timer(0);
            resultSystem = FindAnyObjectByType<ResultSystem>();

            gameStarter = GetComponent<GameStarter>();

            allyBack = FindObjectOfType<AllyBackSpriteRenderer>();
        }

        private void SetupInstance()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;

            allyDataInfo = allyData.Characters[CharacterSelect.SelectCharacterNo];
            enemyDataInfo = enemyData.Characters[(int)SelectStageContainer.EnemyCharacter];
        }

        private void Start()
        {
            state = PuzzleState.Stop;
            allyBack.SetSprite(allyDataInfo.backSprite);
        }

        public void SetGameTimer(float t)
        {
            gameTimerCount = t;
            gameTimer.Start(gameTimerCount);
            gameTimer.OnOnceEnd += EndGame;
        }

        public void GameStartTimerEnd()
        {
            state = PuzzleState.Playable;
            LucKee.BGMManager.Play(bgm);
        }

        private void Update()
        {
            if(gameStarter != null) { return; }
            gameTimer.Update(Time.deltaTime);
        }

        //追加
        //キャラによってBGMを変える
        public void GetBGM(AudioClip Get)
        {
            bgm = Get;
        }
    }
}
