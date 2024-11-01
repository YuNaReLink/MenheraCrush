using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionP : MonoBehaviour
{
    [SerializeField]
    private RectTransform circle;

    [SerializeField]
    private GameObject MaskBack;

    [SerializeField]
    private float speed = 1000;

    [SerializeField]
    private Vector2 StartSiz;

    [SerializeField]
    private bool expand = false;

    //ƒV[ƒ“•Ï‚¦‚é‚â‚Â
    SceneChanger SC = new SceneChanger();

    //// Start is called before the first frame update
    void Start()
    {
        circle.sizeDelta = StartSiz;
    }

    //// Update is called once per frame
    void Update()
    {
        if (!MaskBack.activeSelf)
        {
            return;
        }

        VariableSize();

        if (circle.sizeDelta.x >= 2200)
        {
            MaskBack.SetActive(false);
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
        MaskBack.SetActive(true);
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
