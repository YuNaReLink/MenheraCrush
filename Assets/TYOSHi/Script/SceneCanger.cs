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

    string GetSceneName(SceneList NextScene)
    {
        string a;

        switch (NextScene)
        {
            case SceneList.Titel:
                a = "Title";
                break;
            case SceneList.StageSelect:
                a = "StageSelect";
                break;
            case SceneList.Game:
                a = "GameTYOSHi";
                break;
            default:
                a = "Title";
                break;
        }
        return a;
    }

    public void ChangeScene(SceneList scene)
    {
        SceneManager.LoadScene(GetSceneName(scene));
    }

    public void ButtonClick()
    {
        ChangeScene(NextScene);
    }
}
