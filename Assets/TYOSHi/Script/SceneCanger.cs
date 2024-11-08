using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SceneList
{
    Titel,
    StageSelect,
    Game,

    Count
}

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private SceneList NextScene;

    static string GetSceneName(SceneList NextScene)
    {
        string a;

        switch (NextScene)
        {
            case SceneList.Titel:
                a = "KanataniScene";
                break;
            case SceneList.StageSelect:
                a = "GameStageSelect";
                break;
            case SceneList.Game:
                a = "Game";
                break;
            default:
                a = "KanataniScene";
                break;
        }
        return a;
    }

    public static void ChangeScene(SceneList scene)
    {
        SceneManager.LoadScene(GetSceneName(scene));
    }

    public void ButtonClick()
    {
        ChangeScene(NextScene);
    }
}
