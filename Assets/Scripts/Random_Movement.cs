using UnityEngine;

public class Random_Movement: MonoBehaviour
{
    public float buzzRadius = 0.2f; // Ne kadar uzaklaþabileceði (yarýçap)
    public float buzzSpeed = 1.5f;  // Ne kadar hýzlý hareket edecek

    private Vector3 startPosition;
    private Vector3 targetOffset;

    void Start()
    {
        startPosition = transform.position;
        SetNewTargetOffset();
    }

    void Update()
    {
        // Hareketi yumuþak yap
        transform.position = Vector3.Lerp(transform.position, startPosition + targetOffset, Time.deltaTime * buzzSpeed);

        // Hedefe çok yaklaþtýysa yeni hedef belirle
        if (Vector3.Distance(transform.position, startPosition + targetOffset) < 0.01f)
        {
            SetNewTargetOffset();
        }
    }

    void SetNewTargetOffset()
    {
        // Etrafýnda rastgele küçük bir pozisyon seç
        float offsetX = Random.Range(-buzzRadius, buzzRadius);
        float offsetY = Random.Range(-buzzRadius, buzzRadius);
        targetOffset = new Vector3(offsetX, offsetY, 0f);
    }
}