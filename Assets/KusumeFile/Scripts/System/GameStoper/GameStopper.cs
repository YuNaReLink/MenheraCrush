using UnityEngine;

namespace Kusume
{
    public class GameStopper : MonoBehaviour
    {
        private void OnEnable()
        {
            PlayerController.AddPuzzleStop();
        }

        private void OnDisable()
        {
        PlayerController.DecPuzzleStop();
        }
    }
}
