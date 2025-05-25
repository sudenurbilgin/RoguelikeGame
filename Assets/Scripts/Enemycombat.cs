using UnityEngine;
using TMPro;


public class Enemycombat : MonoBehaviour
{
    public int damage = 1;
    public GameObject popUpPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
        GameObject popUp = Instantiate(popUpPrefab, transform.position, Quaternion.identity);
        popUp.GetComponentInChildren<TMP_Text>().text = damage.ToString();
    }

    public void Attack()
    {
        Debug.Log("attack");
    }
}
