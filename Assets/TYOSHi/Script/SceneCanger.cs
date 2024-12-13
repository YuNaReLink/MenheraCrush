using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SceneList
{
    Title,
    StageSelect,
    Game,

    Count
}

public class SceneChanger : MonoBehaviour
{
    static string GetSceneName(SceneList scene)
    {
        string temp;

        switch (scene)
        {
            case SceneList.Title:
                temp = "TitleScene";
                break;
            case SceneList.StageSelect:
                temp = "GameStageSelect";
                break;
            case SceneList.Game:
                temp = "Game";
                break;
            default:
                temp = "KanataniScene";
                break;
        }
        return temp;
    }

    public static void ChangeScene(SceneList scene)
    {
        SceneManager.LoadScene(GetSceneName(scene));
    }

    [SerializeField] private SceneList nextScene;
    [SerializeField] private Canvas canvas;
    [SerializeField] private SceneTransition transitionPrefab = null;

    private void Awake()
    {
        if (canvas == null)
        {
            canvas = FindAnyObjectByType<Canvas>();
        }
    }

    public void ButtonClick()
    {
        SceneTransition transition = Instantiate(transitionPrefab, canvas.transform);
        transition.gameObject.transform.SetParent(canvas.transform);

        transition.SetNextScene(nextScene);
        transition.Activate();
    }
}
