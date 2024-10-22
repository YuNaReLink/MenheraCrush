using Kusume;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRecovery : MonoBehaviour
{
    private PlayerController player;

    [SerializeField]
    private int regain = 20;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Execute();
    }


    private void Execute()
    {
        player.HP.Regain(regain);
    }
}
