using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Kusume
{
    /// <summary>
    /// ピース同士がつながってることを見えるようにするだけのクラス
    /// </summary>
    public class PieceConcatenate : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer        lineRenderer = null;
        public LineRenderer         LineRenderer => lineRenderer;

        private PlayerController    playerController = null;

        [SerializeField]
        private LineJoint           joint = null;

        [SerializeField]
        [ReadOnly]
        private List<LineJoint> joints = new List<LineJoint>();

        private void Awake()
        {
            lineRenderer = GetComponentInChildren<LineRenderer>();

            playerController = GetComponent<PlayerController>();
        }

        public void Add(Vector3 pos)
        {
            int i = lineRenderer.positionCount;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(i, pos);
            
            LineJoint j = Instantiate(joint, pos,Quaternion.identity);
            j.transform.SetParent(transform);
            joints.Add(j);
        }

        public void Remove()
        {
            lineRenderer.positionCount--;
            Destroy(joints[^1].gameObject);
            joints.RemoveAt(lineRenderer.positionCount);
        }

        public void Clear()
        {
            lineRenderer.positionCount = 0;
            foreach (LineJoint j in joints)
            {
                Destroy(j.gameObject);
            }
            joints.Clear();
        }

        private void Update()
        {
            LineConcatenate();
        }

        private void LineConcatenate()
        {
            List<Vector3> posList = new List<Vector3>();
            List<Piece> pieceList = playerController.PieceList;
            for(int i = 0; i < pieceList.Count; i++)
            {
                Vector3 pos = pieceList[i].transform.position;
                posList.Add(pos);
                joints[i].transform.position = pos;
            }
            lineRenderer.SetPositions(posList.ToArray());
        }
    }
}
