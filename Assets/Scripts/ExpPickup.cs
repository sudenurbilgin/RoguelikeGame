using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int baseExpValue = 1;

    private Transform player;
    private PlayerExp playerExp;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player objesi bulunamadý!");
            return;
        }

        playerExp = player.GetComponent<PlayerExp>();
        if (playerExp == null)
        {
            Debug.LogError("PlayerExp componenti Player objesinde bulunamadý!");
        }
    }

    void Update()
    {
        if (player == null || playerExp == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= playerExp.pickupRadius)
        {
            int scaledExp = Mathf.RoundToInt(baseExpValue * (1f + (playerExp.level - 1) * 0.5f));

            playerExp.GainExp(scaledExp);

            Destroy(gameObject);
        }
    }
}
