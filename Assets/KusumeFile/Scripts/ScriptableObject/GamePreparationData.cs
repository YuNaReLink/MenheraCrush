using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    [Serializable]
    public struct PreparationDatas
    {
        public GameObject pieceMachine;
        public GameObject playerController;
        public GameObject enemyController;
        public void Instantiate()
        {
            GameObject.Instantiate(pieceMachine, pieceMachine.transform.position, Quaternion.identity);
            GameObject.Instantiate(playerController, playerController.transform.position, Quaternion.identity);
            GameObject.Instantiate(enemyController, enemyController.transform.position, Quaternion.identity);
        }
    }

    [CreateAssetMenu(fileName = "GamePreparationData", menuName = "ScriptableObjects/GamePreparationData", order = 1)]
    public class GamePreparationData : ScriptableObject
    {
        [SerializeField]
        private PreparationDatas datas;
        public PreparationDatas Datas => datas;

        [SerializeField]
        private GameObject pieceMachine;
        public GameObject PieceMachine => pieceMachine;
    }
}
