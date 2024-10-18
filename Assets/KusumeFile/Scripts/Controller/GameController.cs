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

        private void Awake()
        {
            SetupInstance();
            gameTimer = new Timer();
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
        }

        // Update is called once per frame
        void Update()
        {
            gameTimer.Update();
        }
    }
}
