using UnityEngine;

namespace Kusume
{
    public class ResultSystem : MonoBehaviour
    {
        //�v���n�u
        [SerializeField]
        private ScoreBoard resultBoard;

        public void Create()
        {
            Instantiate(resultBoard, transform);
        }
    }
}
