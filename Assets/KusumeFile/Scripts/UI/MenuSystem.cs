using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        private SceneChanger sceneChanger;

        [SerializeField]
        private GameObject MenuObject;

        private void Awake()
        {
            GameObject gameController = GameObject.Find("GameController");
            if(gameController != null)
            {
                sceneChanger = gameController.GetComponent<SceneChanger>();
            }
        }

        private void Start()
        {
            buttons[(int)ButtonTag.Menu].onClick.AddListener(MenuStart);
            buttons[(int)ButtonTag.Return].onClick.AddListener(ReturnUpdate);
            buttons[(int)ButtonTag.Configure].onClick.AddListener(ConfigureUpdate);
            buttons[(int)ButtonTag.End].onClick.AddListener(EndUpdate);
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
            sceneChanger?.ChangeScene(SceneList.StageSelect);
        }
    }
}
