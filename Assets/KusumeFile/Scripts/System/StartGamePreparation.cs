using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class StartGamePreparation : MonoBehaviour
    {
        private void OnDestroy()
        {
            GameController.Instance.SetPreparation();
        }
    }
}
