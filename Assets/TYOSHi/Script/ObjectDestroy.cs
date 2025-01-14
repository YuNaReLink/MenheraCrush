using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDesttroy : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    public void  Clicck()
    {
        Destroy(parent);
    }
}
