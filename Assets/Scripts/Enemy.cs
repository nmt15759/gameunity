using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    protected PlayerController player;
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        MoveToPlayer();
    }

    protected void MoveToPlayer()
    {
        if (player == null) return;

        Vector2 direction = (player.transform.position - transform.position).normalized;
        Vector2 move = direction * moveSpeed * Time.fixedDeltaTime;

        // Dùng MovePosition để tôn trọng va chạm vật lý
        rb.MovePosition(rb.position + move);

        FlipEnemy();
    }

    protected void FlipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(
                player.transform.position.x < transform.position.x ? -1 : 1,
                1, 1
            );
        }
    }
}
