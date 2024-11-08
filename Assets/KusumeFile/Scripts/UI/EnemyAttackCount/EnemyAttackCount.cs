using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class EnemyAttackCount : MonoBehaviour
    {
        [SerializeField]
        private Text countText;

        [SerializeField]
        private EnemyController controller;

        [SerializeField]
        private int count = 0;
        public int Count => count;

        private void Awake()
        {
            controller = FindObjectOfType<EnemyController>();
            countText = GetComponent<Text>();
        }

        private void Start()
        {
            count = 3;
        }

        public void CountUpdate()
        {
            count--;
            if (count < 0)
            {
                count = 3;
            }
            countText.text = count.ToString();
        }
    }
}
