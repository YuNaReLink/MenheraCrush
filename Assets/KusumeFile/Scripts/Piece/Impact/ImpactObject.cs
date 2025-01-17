using UnityEngine;

namespace Kusume
{

    [RequireComponent(typeof(CircleCollider2D))]
    public class ImpactObject : MonoBehaviour
    {
        private CircleCollider2D circleCollider;

        [SerializeField]
        private float duration = 1.0f;

        [SerializeField]
        private float radiusSpeed = 0.01f;

        [SerializeField]
        private float power = 1.0f;

        private void Awake()
        {
            circleCollider = GetComponent<CircleCollider2D>();
        }

        void Start()
        {
            circleCollider.isTrigger = true;
        }


        private void Update()
        {
            float delta = Time.deltaTime;
            duration -= delta;
            if(duration <= 0)
            {
                Destroy(gameObject);
            }

            circleCollider.radius += radiusSpeed * delta;

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Piece piece = collision.GetComponent<Piece>();
            
            if(piece == null) { return; }
            if(piece.transform.position.y < transform.position.y) { return; }

            Vector2 dir = piece.transform.position - transform.position;
            Rigidbody2D rb = piece.GetComponent<Rigidbody2D>();
            rb.AddForce(dir * power,ForceMode2D.Impulse);
            //piece.SetImpactPower(power * 0.8f);
            piece.SetImpactPower(0);
        }
    }
}
