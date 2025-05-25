using UnityEngine;
using TMPro;

public class Player_combat : MonoBehaviour
{
    public Transform attackPoint;
    public float weaponRange = 1;
    public LayerMask enemyLayer;
    public int damage = 1;

    public Animator anim;

    public float cooldown = 1;
    private float timer;

    public GameObject popUpPrefab;


    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if(timer <= 0)
        {
            anim.SetBool("isAttacking", true);

            timer = cooldown;
        }
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            Collider2D enemy = enemies[0];


            GameObject popUp = Instantiate(popUpPrefab, enemy.transform.position, Quaternion.identity);
            popUp.GetComponentInChildren<TMP_Text>().text = damage.ToString();
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-damage);
        }
    }

    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }
}
