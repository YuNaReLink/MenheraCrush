using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHider : MonoBehaviour
{
    [SerializeField] private GameObject originObject;
    [SerializeField] private Canvas canvase;

    public void Reveal()
    {
        GameObject cloneObject = Instantiate(originObject, canvase.transform);
    }
}
