using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Kusume 
{
    public class SkillButton : MonoBehaviour
    {
        private Button button;

        public void Setup(UnityAction action)
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(action);
        }
    }
}

