using UnityEngine;

public class Enemy_Movemnt : MonoBehaviour
{
    public float speed;
    private int facingDirection = -1;
    private EnemyState enemyState;

    public float attackRange = 2; // Distance to trigger attack animation

    private Rigidbody2D rb;
    private Animator anim;

    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);

        // Player objesini tag �zerinden bul
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player object not found in scene. Make sure it has the tag 'Player'.");
        }
    }

    void Update()
    {
        if (player == null) return;
        Chase();
    }

    void Chase()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= attackRange)
        {
            ChangeState(EnemyState.Attacking);
        }
        else
        {
            ChangeState(EnemyState.Idle);
        }

        if (player.position.x > transform.position.x && facingDirection == -1 ||
            player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }

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
