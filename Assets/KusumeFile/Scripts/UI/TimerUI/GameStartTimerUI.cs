using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class GameStartTimerUI : MonoBehaviour
    {
        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        private void Start()
        {
            text.text = "";
        }

        private void Update()
        {
            if (GameController.Instance.GameStartTimer.IsEnd())
            {
                Destroy(gameObject);
                return;
            }
            int count = (int)GameController.Instance.GameStartTimer.Current;
            text.text = count.ToString();
        }
    }
}
