using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string NextSceneName;

    public void ButtonClick()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
