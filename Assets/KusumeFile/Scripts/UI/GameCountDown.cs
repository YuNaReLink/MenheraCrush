using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class GameCountDown : MonoBehaviour
    {
        [SerializeField]
        private Text timerCountText;

        private void Awake()
        {
            timerCountText = GetComponent<Text>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            CountRefresh();
        }

        private void CountRefresh()
        {
            if (GameController.Instance.GameTimer.IsEnd()) { return; }
            Timer timer = GameController.Instance.GameTimer;
            int m = timer.GetMinutes();
            int s = timer.GetSecond();
            timerCountText.text = string.Format("{0:00}:{1:00}", m, s);

        }
    }
}
