using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class GameStarter : MonoBehaviour
    {
        private static GameStarter instance;
        public static GameStarter Instance => instance;

        private Timer gameStartTimer;
        public Timer GameStartTimer => gameStartTimer;
        [SerializeField]
        private float gameStartCountSpeed = 0.5f;

        [SerializeField]
        private float gameStartCount = 3.0f;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;

            gameStartTimer = new Timer(0);
        }

        public void Activate()
        {
            gameStartTimer.Start(gameStartCount);
            gameStartTimer.OnOnceEnd += GameController.Instance.GameStartTimerEnd;
            gameStartTimer.OnOnceEnd += Destroy;
        }

        private void Destroy()
        {
            Destroy(this);
        }

        private void Update()
        {
            gameStartTimer.Update(Time.deltaTime * gameStartCountSpeed);
        }
    }
}
