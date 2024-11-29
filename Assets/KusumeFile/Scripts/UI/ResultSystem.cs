using UnityEngine;

namespace Kusume
{
    public class ResultSystem : MonoBehaviour
    {
        //ƒvƒŒƒnƒu
        [SerializeField]
        private ScoreBoard resultBoard;

        public void Create()
        {
            Instantiate(resultBoard, transform);
        }
    }
}
