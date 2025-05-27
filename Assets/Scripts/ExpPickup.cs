using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int expValue = 1;

    private Transform player;
    private PlayerExp playerExp;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerExp = player.GetComponent<PlayerExp>();
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            float pickupRadius = player.GetComponent<PlayerExp>().pickupRadius;
            if (distance <= pickupRadius)
            {
                player.GetComponent<PlayerExp>().GainExp(expValue);
                Destroy(gameObject);
                Debug.Log("EXP collected");
            }
        }
    }

}
