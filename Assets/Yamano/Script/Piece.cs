using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LucKee
{
    enum PieceTag
    {
        Null,
        Piece0,
        Piece1,
        Piece2,
        Piece3,
        Count
    }
    enum SizeTag
    {
        Null,
        Size0,
        Size1,
        Size2,
        Size3,
        Count
    }
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Piece : MonoBehaviour
    {
        [SerializeField]
        private new PieceTag tag = PieceTag.Null;
        [SerializeField]
        private SizeTag size = SizeTag.Null;
        float wait = -1;

        private new SpriteRenderer renderer = null;
        private void Start()
        {
            if (tag == PieceTag.Null)
            {
                Destroy(gameObject);
                return;
            }
            renderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (wait < 0)
            {
                return;
            }
            wait -= Time.deltaTime;
            if (wait < 0)
            {
                Impact();
                Destroy(gameObject);
            }
        }

        public void Crush(float w)
        {
            wait = w;
        }
        private void Impact()
        {
            float power = GetPower();
            if (power <= 0)
            {
                return;
            }
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, GetRadius(), new Vector2());
            foreach (RaycastHit2D hit in hits)
            {
                Vector2 diff = hit.point - (Vector2)transform.position;
                Rigidbody2D rigid = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                if (rigid == null)
                {
                    continue;
                }
                Vector2 force = diff.normalized;
                force *= power;
                rigid.AddForce(force);
            }
        }
        private float GetPower()
        {
            float power = 0;
            switch (size)
            {
                case SizeTag.Size1:
                    power = 1;
                    break;
                case SizeTag.Size2:
                    power = 2;
                    break;
                case SizeTag.Size3:
                    power = 3;
                    break;
                default:
                    break;
            }
            return power;
        }
        private float GetRadius()
        {
            float radius = 0;
            switch (size)
            {
                case SizeTag.Size1:
                    radius = 1;
                    break;
                case SizeTag.Size2:
                    radius = 3;
                    break;
                case SizeTag.Size3:
                    radius = 5;
                    break;
                default:
                    break;
            }
            return radius;
        }
    }
}
