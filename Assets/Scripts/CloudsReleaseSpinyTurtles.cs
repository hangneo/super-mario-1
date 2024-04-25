using System.Collections;
using UnityEngine;

public class CloudsReleaseSpinyTurtles : MonoBehaviour
{
    public GameObject spinyTurtlePrefab; // Prefab của rùa
    public float releaseInterval; // Thời gian giữa mỗi lần thả rùa
    public Transform releasePoint; // Vị trí thả rùa
    public float initialSpeed = 5f; // Vận tốc ban đầu của rùa
    public float launchAngle = 45f; // Góc ném của rùa

    void Start()
    {
        StartCoroutine(ReleaseTurtle());
    }

    IEnumerator ReleaseTurtle()
    {
        while (true)
        {
            yield return new WaitForSeconds(releaseInterval);

            // Thả rùa
            GameObject turtle = Instantiate(spinyTurtlePrefab, releasePoint.position, Quaternion.identity);

            // Tính toán vận tốc ban đầu và hướng di chuyển của rùa
            Vector2 launchDirection = Quaternion.Euler(0, 0, launchAngle) * Vector2.right;
            Vector2 initialVelocity = launchDirection * initialSpeed;

            // Áp dụng vận tốc ban đầu cho rùa
            Rigidbody2D rb = turtle.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = initialVelocity;
            }
        }
    }
}
