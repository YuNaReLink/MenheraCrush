using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCaller : MonoBehaviour
{
    [SerializeField]
    private Kusume.MenuController menu;

    [SerializeField]
    private GameObject charaSelect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!charaSelect.activeSelf)
            {
                menu.gameObject.SetActive(!menu.gameObject.activeSelf);
            }
        }
    }
}
