using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBack : MonoBehaviour
{
    [SerializeField]
    private RectTransform circle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

            circle.sizeDelta += Vector2.one * 500 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            circle.sizeDelta -= Vector2.one * 500 * Time.deltaTime;

        }
    }
}
