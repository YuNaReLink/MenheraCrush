using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceChanger : MonoBehaviour
{
    [SerializeField]
    private SceneTransition transitionPrefab = null;

    [SerializeField]
    private Sprite backSprite;

    [SerializeField]
    private Image backImage;

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private Image[] images;

    [SerializeField]
    private SceneList nextScene;

    [SerializeField]
    private Canvas canvas;

    public void Click()
    {
        for(int i=0; i < images.Length;i++)
        {
            images[i].sprite = sprites[i];
        }
        if(backImage != null && backSprite != null)
        {
            backImage.sprite = backSprite;
        }

        SceneTransition transition = Instantiate(transitionPrefab, canvas.transform);
        transition.gameObject.transform.SetParent(canvas.transform);

        transition.SetNextScene(nextScene);
        transition.Activate();
    }
}
