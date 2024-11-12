using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceChanger : MonoBehaviour
{
    [SerializeField]
    private SceneTransition transitionPrefab = null;

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private Image[] images;

    public void Click()
    {
        for(int i=0; i < images.Length;i++)
        {
            images[i].sprite = sprites[i];
        }
        Canvas canvas = FindAnyObjectByType<Canvas>();
        SceneTransition transition = Instantiate(transitionPrefab, canvas.transform);
        transition.Activate();
    }
}
