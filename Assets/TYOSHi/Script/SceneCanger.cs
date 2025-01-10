using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Kusume;
using LucKee;

public enum SceneList
{
    Title,
    StageSelect,
    Game,

    Count
}

//âzå†(LucKeeÅF2024/12/24)
public class SceneChanger : MonoBehaviour
{
    private void Awake()
    {
        
    }


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
                temp = "TitleScene";
                break;
        }
        return temp;
    }

    public static void ChangeScene(SceneList scene)
    {
        SceneManager.LoadScene(GetSceneName(scene));
    }

    [SerializeField]
    private SceneList nextScene;

    [SerializeField]
    private TransitionCloser transitionPrefab = null;

    public void Execute()
    {
        TransitionCloser closer = Instantiate(transitionPrefab);
        closer.SetNext(nextScene);
    }
}
