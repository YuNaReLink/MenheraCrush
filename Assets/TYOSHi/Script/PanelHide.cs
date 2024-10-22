using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHide : MonoBehaviour
{
    [SerializeField] private GameObject Panel;

    public void Clikk()
    {
        Panel.SetActive(true);
    }
    
    public void BuckClikk()
    {
        Panel.SetActive(false);
    }
}
