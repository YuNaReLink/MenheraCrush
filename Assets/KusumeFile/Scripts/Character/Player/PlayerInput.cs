using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// 単純にキーの入力やってるだけ
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        private bool    leftMouseButton = false;
        public bool     LeftMouseButton => leftMouseButton;
        [SerializeField]
        private bool    rightMouseButton = false;
        public bool     RightMouseButton => rightMouseButton;

        public void ButtonInput()
        {
            leftMouseButton = Input.GetMouseButton(0);
            rightMouseButton = Input.GetMouseButton(1);
        }
    }
}
