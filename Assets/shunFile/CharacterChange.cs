using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChange : MonoBehaviour
{
    [SerializeField]
    private SceneTransitionP transitionPrefab = null;

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private Image[] images;

    public void Button()
    {
        for(int i=0;i< images.Length;i++)
        {
            images[i].sprite = sprites[i];
        }
        Canvas canvas = FindAnyObjectByType<Canvas>();
        SceneTransitionP transition = Instantiate(transitionPrefab, canvas.transform);
        transition.Brack();
    }
}
