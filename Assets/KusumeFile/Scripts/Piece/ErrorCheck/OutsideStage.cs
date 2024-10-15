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

            // �X�N���[���̉������̍��W�i���[���h���W���擾�������̂ŃX�N���[�����W��Y��0�ɂ���j
            Vector3 bottomScreenPoint = new Vector3(Screen.width / 2, 0, mainCamera.nearClipPlane);

            // �X�N���[�����W�����[���h���W�ɕϊ�
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