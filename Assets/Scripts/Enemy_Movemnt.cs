using UnityEngine;

public class Enemy_Movemnt : MonoBehaviour
{
    public float speed;
    private int facingDirection = -1;
    private EnemyState enemyState;

    public float attackRange = 2; // Distance to trigger attack animation

    private Rigidbody2D rb;
    public Transform player;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    void Update()
    {
        Chase(); // Always chase, no stopping
    }

    void Chase()
    {
        // Check if player is in attack range to trigger attack animation
        if (Vector2.Distance(transform.position, player.transform.position) <= attackRange)
        {
            ChangeState(EnemyState.Attacking);
        }
        else
        {
            ChangeState(EnemyState.Idle);
        }

        // Flip direction based on player position
        if (player.position.x > transform.position.x && facingDirection == -1 ||
            player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }

        // Move toward player continuously
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", false);

        enemyState = newState;

        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", true);
    }

    public enum EnemyState
    {
        Idle,
        Attacking
    }
}