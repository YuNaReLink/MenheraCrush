using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionP : MonoBehaviour
{
    private Kusume.Timer t = new();


    [SerializeField]
    private RectTransform circle;

    [SerializeField]
    private float speed = 1000;

    [SerializeField]
    private float maxSize = 2200;

    [SerializeField]
    private bool expand = false;

    //ƒV[ƒ“•Ï‚¦‚é‚â‚Â
    SceneChanger SC = new SceneChanger();

    //// Start is called before the first frame update
    void Awake()
    {
        if (expand)
        {
            circle.sizeDelta = Vector2.zero;
        }
        else
        {
            circle.sizeDelta = Vector2.one * maxSize;
        }
    }

    //// Update is called once per frame
    void Update()
    {
        t.Update();
        
        if (!t.IsEnd())
        {
            return;
        }

        VariableSize();

        if (circle.sizeDelta.x >= maxSize)
        {
            Destroy(gameObject);
            return;
        }

        //‰æ–Ê‚ª•‚­‚È‚Á‚½‚ç
        if (circle.sizeDelta.x <= 0.0f)
        {
            SC.ChangeScene(SceneList.StageSelect);
        }
    }

    public void Brack()
    {
        t.Start(0.5f);
    }

    public void VariableSize()
    {
        if (expand)
        {
            circle.sizeDelta += speed * Time.deltaTime * Vector2.one;
        }
        else
        {
            circle.sizeDelta -= speed * Time.deltaTime * Vector2.one;
        }
    }
}
