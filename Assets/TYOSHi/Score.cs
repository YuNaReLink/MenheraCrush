using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;

    [SerializeField] private Text Text;
    [SerializeField] private Text ResertText;
    [SerializeField] private GameObject Borde;


    public void Click()
    {
        score += 100;
        Text.text=score.ToString();
    }
    
    public void EndClick()
    {
        ResertText.text = Text.text;
        Borde.SetActive(true);
    }
}
