using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class GameStartTimerUI : MonoBehaviour
    {
        private Text text;

        [SerializeField]
        private GameObject StartUI;

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
                GameObject g = Instantiate(StartUI,transform.position, Quaternion.identity);
                g.transform.SetParent(transform.parent);
                Destroy(gameObject);
                return;
            }
            int count = (int)GameController.Instance.GameStartTimer.Current;
            text.text = count.ToString();
        }
    }
}
