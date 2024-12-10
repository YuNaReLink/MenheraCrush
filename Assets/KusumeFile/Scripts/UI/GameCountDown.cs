using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class GameCountDown : MonoBehaviour
    {
        private LucKee.SpriteConverter converter;
        private void Awake()
        {
            converter = GetComponent<LucKee.SpriteConverter>();
        }

        private void Start()
        {
            SetTimeText(0, 0);
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
            SetTimeText(m, s);
        }

        private void SetTimeText(int m ,int s)
        {
            converter.SetText(string.Format("{0:00}:{1:00}", m, s));
        }
    }
}
