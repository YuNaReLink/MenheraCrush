using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.PlayerLoop.PreUpdate;

public class ResultSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject resultPanel;

    [SerializeField]
    private SceneList returnScene = SceneList.Game;

    [SerializeField]
    private SceneList backScene = SceneList.StageSelect;

    [SerializeField]
    private List<Button> buttons = new List<Button>();

    private void Start()
    {
        UnityAction unityAction = null;
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i] == null) { continue; }
            switch (i)
            {
                case 0:
                    unityAction = Return;
                    break;
                case 1:
                    unityAction = Back;
                    break;
            }
            buttons[i].onClick.AddListener(unityAction);
        }
    }

    private void Return()
    {
        SceneChanger.ChangeScene(returnScene);
    }

    private void Back()
    {
        SceneChanger.ChangeScene(backScene);
    }
}
