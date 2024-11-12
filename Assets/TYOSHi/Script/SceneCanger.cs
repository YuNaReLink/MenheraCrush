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
    [SerializeField] private SceneList nextScene;

    static string GetSceneName(SceneList scene)
    {
        string temp;

        switch (scene)
        {
            case SceneList.Title:
                temp = "KanataniScene";
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

    public void ButtonClick()
    {
        ChangeScene(nextScene);
    }
}
