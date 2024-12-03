using UnityEngine;

namespace Kusume
{
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


        private CharacterInfo allyData;
        public CharacterInfo AllyData => allyData;
        public void SetAllyData(CharacterInfo data) { allyData = data;}

        //private CharacterInfo enemyData;

        public void SetPreparation()
        {
            //準備時の用意するオブジェクトを作成
            preparationData.Datas.Instantiate();
        }

        private bool                    puzzleStop = false;
        public bool                     IsPuzzleStop => puzzleStop;
        public void                     SetPuzzleStop(bool b) { puzzleStop = b;}

        public bool                     endGame = false;
        public bool                     IsEndGame => endGame;
        public void EndGame() 
        {
            endGame = true;
            resultSystem.Create();
        }

        private ResultSystem resultSystem;

        private void Awake()
        {
            SetupInstance();
            gameTimer = new Timer(0);
            resultSystem = FindAnyObjectByType<ResultSystem>();
        }

        private void SetupInstance()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }

        private void Start()
        {
            endGame = false;
            puzzleStop = true;
        }

        public void SetGameTimer(float t)
        {
            gameTimerCount = t;
            gameTimer.Start(gameTimerCount);
            gameTimer.OnOnceEnd += EndGame;
        }

        public void GameStartTimerEnd()
        {
            puzzleStop = false;
            LucKee.BGMManager.Play(bgm);
        }

        private void Update()
        {
            gameTimer.Update(Time.deltaTime);
        }
    }
}
