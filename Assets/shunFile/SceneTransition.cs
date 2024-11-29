using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    private Kusume.Timer timer = new();

    [SerializeField]
    private RectTransform circle;

    [SerializeField]
    private float speed = 1000;

    [SerializeField]
    private float maxSize = 2200;

    [SerializeField]
    private bool expand = false;

    [SerializeField]
    private float duration = 0.5f;

    private SceneList nextScene = SceneList.Title;
    public void SetNextScene(SceneList n) {  nextScene = n; }

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
        timer.Update(Time.deltaTime);
        
        if (!timer.IsEnd())
        {
            return;
        }

        UpdateSize();

        if (circle.sizeDelta.x >= maxSize)
        {
            Destroy(gameObject);
            return;
        }

        //‰æ–Ê‚ª•‚­‚È‚Á‚½‚ç
        if (circle.sizeDelta.x <= 0.0f)
        {
            SceneChanger.ChangeScene(nextScene);
        }
    }

    public void Activate()
    {
        timer.Start(duration);
    }

    public void UpdateSize()
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
