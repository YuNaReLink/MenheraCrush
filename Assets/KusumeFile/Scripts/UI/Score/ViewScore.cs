using UnityEngine;
using UnityEngine.UI;

namespace Kusume
{
    public class ViewScore : MonoBehaviour
    {
        private Text scoreText;

        private int subScore;

        private void Awake()
        {
            scoreText = GetComponent<Text>();
        }


        private void Start()
        {
            subScore = GameScore.Count;
        }


        private void Update()
        {
            if(subScore >= GameScore.Count) { return; }
            subScore += 10;
            scoreText.text = subScore.ToString("D8");
        }
    }
}
