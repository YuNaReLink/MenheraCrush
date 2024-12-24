using UnityEngine;

namespace Kusume
{
    public class ReadyGameStarter : MonoBehaviour
    {
        private void OnDisable()
        {
            if (GameController.Instance != null)
            {
                GameController.Instance.SetPreparation();
            }
        }
    }
}

