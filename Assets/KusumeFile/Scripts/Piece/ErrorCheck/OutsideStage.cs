using System.Collections.Generic;
using UnityEngine;

namespace Kusume
{
    public class OutsideStage : MonoBehaviour
    {
        [SerializeField]
        private CreatePieceMachine createPieceMachine;

        private void Awake()
        {
            createPieceMachine = GetComponent<CreatePieceMachine>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            Check();
        }

        private void Check()
        {
            Camera mainCamera = Camera.main;

            // スクリーンの下部分の座標（ワールド座標を取得したいのでスクリーン座標のYを0にする）
            Vector3 bottomScreenPoint = new Vector3(Screen.width / 2, 0, mainCamera.nearClipPlane);

            // スクリーン座標をワールド座標に変換
            Vector3 worldBottomPosition = mainCamera.ScreenToWorldPoint(bottomScreenPoint);
            List<GameObject> pieces = createPieceMachine.Pieces;
            for (int i = 0; i < pieces.Count; i++)
            {
                if(pieces[i] == null)
                {
                    continue; 
                }
                if (pieces[i].transform.position.y > worldBottomPosition.y)
                {
                    continue;
                }
                CreatePieceMachine.CurrentPieceCount--;
                Destroy(pieces[i].gameObject);
                createPieceMachine.PieceRemove(i);
            }
        }

    }
}
