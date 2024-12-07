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
        private GameObject MenuObject;

        private FaceChanger faceChanger;

        private AudioSource audioSource;

        private LucKee.Pause pause;

        [SerializeField]
        private AudioClip audioClip;

        private void Awake()
        {
            faceChanger = GetComponent<FaceChanger>();

            audioSource = GetComponent<AudioSource>();

            pause = GetComponent<LucKee.Pause>();
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
            audioSource.PlayOneShot(audioClip);
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
            pause.Enable();
        }

        private void ReturnUpdate()
        {
            MenuActive(false);
            pause.Disable();
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
