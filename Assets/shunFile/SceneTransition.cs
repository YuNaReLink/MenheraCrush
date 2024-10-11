using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    var fader = new FadeTransition()
    {
        nextScene = SceneManager.GetSceneByName("KanataniScene").buildIndex,
        fadedDelay = 0.2f,
        fadeToColor = Color.black
    };
    TransitionKit.instance.transitionWithDelegate(ImageMaskTransition);
}
