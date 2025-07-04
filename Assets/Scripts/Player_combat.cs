using UnityEngine;
using TMPro;

public class Player_combat : MonoBehaviour
{
    public float critChance = 0f; // 0 to 1
    public Transform attackPoint;
    public float weaponRange = 1;
    public LayerMask enemyLayer;
    public int damage = 1;

    public Animator anim;

    public float cooldown = 1;
    private float timer;

    public GameObject popUpPrefab;

    public AudioSource attackAudioSource;
    public AudioClip attackClip;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (timer <= 0 && !anim.GetBool("isAttacking"))
        {
            anim.SetBool("isAttacking", true);
            timer = cooldown;

            if (attackAudioSource != null && attackClip != null)
            {
                attackAudioSource.PlayOneShot(attackClip);
            }
        }
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            Collider2D enemy = enemies[0];
            int finalDamage = damage;

            if (Random.value < critChance)
            {
                finalDamage *= 2;
                Debug.Log("CRITICAL HIT!");
            }

            GameObject popUp = Instantiate(popUpPrefab, enemy.transform.position, Quaternion.identity);
            popUp.GetComponentInChildren<TMP_Text>().text = finalDamage.ToString();
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-finalDamage);
        }
    }

    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }
}
