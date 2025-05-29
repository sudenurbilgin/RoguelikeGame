using UnityEngine;

public class Random_Movement: MonoBehaviour
{
    public float buzzRadius = 0.2f; // Ne kadar uzakla�abilece�i (yar��ap)
    public float buzzSpeed = 1.5f;  // Ne kadar h�zl� hareket edecek

    private Vector3 startPosition;
    private Vector3 targetOffset;

    void Start()
    {
        startPosition = transform.position;
        SetNewTargetOffset();
    }

    void Update()
    {
        // Hareketi yumu�ak yap
        transform.position = Vector3.Lerp(transform.position, startPosition + targetOffset, Time.deltaTime * buzzSpeed);

        // Hedefe �ok yakla�t�ysa yeni hedef belirle
        if (Vector3.Distance(transform.position, startPosition + targetOffset) < 0.01f)
        {
            SetNewTargetOffset();
        }
    }

    void SetNewTargetOffset()
    {
        // Etraf�nda rastgele k���k bir pozisyon se�
        float offsetX = Random.Range(-buzzRadius, buzzRadius);
        float offsetY = Random.Range(-buzzRadius, buzzRadius);
        targetOffset = new Vector3(offsetX, offsetY, 0f);
    }
}