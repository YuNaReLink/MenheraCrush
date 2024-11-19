using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHider : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void Reveal()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
