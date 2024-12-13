using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite backSprite;

    [SerializeField]
    private Image backImage;

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
        if(backImage != null && backSprite != null)
        {
            backImage.sprite = backSprite;
        }

    }
}
