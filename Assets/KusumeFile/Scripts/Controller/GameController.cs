using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class GameController : MonoBehaviour
    {

        private static GameController instance;
        public static GameController Instance => instance;

        private Timer gameTimer;
        public Timer GameTimer => gameTimer;

        [SerializeField]
        private float gameTimerCount = 60.0f;

        private bool puzzleStop = false;
        public bool IsPuzzleStop => puzzleStop;
        public void SetPuzzleStop(bool b) { puzzleStop = b;}

        public bool endGame = false;
        public bool IsEndGame => endGame;
        public void EndGame() 
        {
            endGame = true;
            Instantiate(resultSystem.ResultBoard, resultSystem.transform);
        }

        private ResultSystem resultSystem;

        private void Awake()
        {
            SetupInstance();
            gameTimer = new Timer();
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
            gameTimer.Start(gameTimerCount);
            gameTimer.OnOnceEnd += EndGame;
            endGame = false;
            puzzleStop = false;
        }

        // Update is called once per frame
        void Update()
        {
            gameTimer.Update();
        }
    }
}
