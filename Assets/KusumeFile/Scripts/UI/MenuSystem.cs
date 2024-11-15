using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Kusume
{
    public enum ButtonTag
    {
        Menu,
        Return,
        Configure,
        End
    }
    public class MenuController : MonoBehaviour
    {
        [SerializeField]
        private List<Button> buttons = new List<Button>();

        [SerializeField]
        private SceneList nextScene = SceneList.StageSelect;

        [SerializeField]
        private GameObject MenuObject;

        private FaceChanger faceChanger;

        private void Awake()
        {
            faceChanger = GetComponent<FaceChanger>();
        }
        private void Start()
        {
            UnityAction unityAction = null;
            for(int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i] == null) { continue; }
                switch (i)
                {
                    case 0:
                        unityAction = MenuStart;
                        break;
                    case 1:
                        unityAction = ReturnUpdate;
                        break;
                    case 2:
                        unityAction = ConfigureUpdate;
                        break;
                    case 3:
                        unityAction = EndUpdate;
                        break;
                }
                buttons[i].onClick.AddListener(unityAction);
            }
        }

        private void MenuActive(bool a)
        {
            MenuObject?.SetActive(a);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MenuStart();
            }
        }

        private void MenuStart()
        {
            MenuActive(true);
        }

        private void ReturnUpdate()
        {
            MenuActive(false);
        }

        private void ConfigureUpdate()
        {

        }

        private void EndUpdate()
        {
            faceChanger.Click();
        }
    }
}
