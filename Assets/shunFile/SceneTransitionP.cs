using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionP : MonoBehaviour
{
    [SerializeField]
    private RectTransform circle;
    //// Start is called before the first frame update
    void Start()
    {

    }

    //// Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

            circle.sizeDelta += Vector2.one * 1600 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            circle.sizeDelta -= Vector2.one * 1600 * Time.deltaTime;

        }
    }

    public void Brack()
    {
        if (circle.sizeDelta.x < 0)
        {
            circle.sizeDelta += Vector2.one * 100 * Time.deltaTime;

        }
        else if(circle.sizeDelta.x > 2200)
        {
            circle.sizeDelta -= Vector2.one * 100 * Time.deltaTime;
        }
    }


}
