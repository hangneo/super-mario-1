using UnityEngine;

public class CloudsFollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 targetPosition;
    public float normalMovementSpeed; // Tốc độ di chuyển bình thường của mây
    public float chaseMovementSpeed; // Tốc độ di chuyển khi đuổi theo nhân vật
    public float movementRange; // Khoảng cách mà mây di chuyển qua lại
    public float deviationRange; // Khoảng cách mây lệch nhân vật
    public float chaseThreshold; // Ngưỡng khoảng cách để bắt đầu đuổi theo nhân vật
    public Animator amt;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        CalculateNewTargetPosition();
    }

    private void Start() {
        normalMovementSpeed = Random.Range(2f, 5f);
        chaseMovementSpeed = 10f;
        movementRange = 2f;
        deviationRange = 4f;
        chaseThreshold = 5f;
        amt = GetComponent<Animator>();
        amt.SetBool("death", false);
    }
    private void Update()
    {
        float distanceToPlayer = Mathf.Abs(player.position.x - transform.position.x);

        // Kiểm tra xem cần đuổi theo nhân vật hay không
        if (distanceToPlayer > chaseThreshold)
        {
            // Đuổi theo nhân vật với tốc độ tăng lên
            MoveTowardsPlayer(chaseMovementSpeed);
        }
        else
        {
            // Di chuyển mây với tốc độ bình thường
            MoveTowardsPlayer(normalMovementSpeed);
        }
    }

    private void MoveTowardsPlayer(float speed)
    {
        // Di chuyển mây đến vị trí mới
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Nếu mây đã đến vị trí mới, tính toán một vị trí mới để di chuyển đến
        if (transform.position == targetPosition)
        {
            CalculateNewTargetPosition();
        }
    }

    private void CalculateNewTargetPosition()
    {
        // Tính toán vị trí ngẫu nhiên trên trục x
        float randomX = Random.Range(player.position.x - movementRange, player.position.x + movementRange + deviationRange);

        // Lấy vị trí y và z hiện tại của mây
        float y = transform.position.y;

        // Cập nhật targetPosition với vị trí mới
        targetPosition = new Vector3(randomX, y, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.starpower) {
                
                EnterShell();
            } else if (collision.transform.DotTest(transform, Vector2.down)) {
                EnterShell();
            }  else {
                player.Hit();
            }
        }
    }

    private void EnterShell()
    {
        amt.SetBool("death", true);
        GetComponent<DeathAnimation>().enabled = true;
        Destroy(gameObject, 1f);
    }

    private void Hit()
    {
        Destroy(gameObject, 1f);
    }
}
