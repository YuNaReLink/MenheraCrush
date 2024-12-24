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

        private void Start()
        {
            LucKee.TransitionHole transitionHole = FindObjectOfType<LucKee.TransitionHole>();
            if(transitionHole == null)
            {
                Activate();
            }
            else
            {
                transitionHole.OnFinished += Activate;
            }
        }

        public void Activate()
        {
            gameStartTimer.Start(gameStartCount);
            gameStartTimer.OnOnceEnd += GameController.Instance.GameStartTimerEnd;
            gameStartTimer.OnOnceEnd += Destroy;
            if (GameController.Instance != null)
            {
                GameController.Instance.SetPreparation();
            }
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
