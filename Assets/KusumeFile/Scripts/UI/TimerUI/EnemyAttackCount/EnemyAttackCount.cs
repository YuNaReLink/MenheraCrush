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

        [SerializeField]
        private int maxCount = 3;

        public int Count => count;

        [SerializeField]
        private Color[] colors = new Color[]
        {
            Color.red,
            Color.yellow,
            Color.white,
        };

        [SerializeField]
        private float[] colorNormailze = new float[]
        {
            1.0f,
            0.7f,
            0.4f
        };

        private void Awake()
        {
            controller = FindObjectOfType<EnemyController>();
            countText = GetComponent<Text>();
        }

        private void Start()
        {
            count = maxCount;
            countText.text = count.ToString();
        }

        public void CountUpdate()
        {
            count--;
            if (count < 0)
            {
                count = maxCount;
            }
            float normailzeCount = (float)count / maxCount;
            int c = 0;
            if(normailzeCount <= colorNormailze[0] && normailzeCount > colorNormailze[1])
            {
                c = 2;
            }
            else if (normailzeCount <= colorNormailze[1] && normailzeCount > colorNormailze[2])
            {
                c = 1;
            }
            else if(normailzeCount <= colorNormailze[2])
            {
                c = 0;
            }
            countText.color = colors[c];
            countText.text = count.ToString();
        }
    }
}
