using UnityEngine;
using TMPro;

public class Enemycombat : MonoBehaviour
{
    public int damage = 1;
    public GameObject popUpPrefab;

    public float damageCooldown = 1f;
    private float lastDamageTime = -999f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.ChangeHealth(-damage);

                    GameObject popUp = Instantiate(popUpPrefab, transform.position, Quaternion.identity);
                    popUp.GetComponentInChildren<TMP_Text>().text = damage.ToString();

                    lastDamageTime = Time.time;
                    Debug.Log("attack");
                }
            }
        }
    }
}
