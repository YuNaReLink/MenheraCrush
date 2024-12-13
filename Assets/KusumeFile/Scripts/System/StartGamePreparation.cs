using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class StartGamePreparation : MonoBehaviour
    {
        /*
        private void OnDestroy()
        {
            GameController.Instance.SetPreparation();
        }
         */

        public void Create()
        {
            GameController.Instance.SetPreparation();
            Destroy(gameObject);
        }
    }
}
