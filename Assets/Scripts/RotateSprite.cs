using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RotateSprite : MonoBehaviour
{
    public Sprite[] sprites; // Mảng chứa các frame của animation 1
    public float rotationSpeed = 300f; // Tốc độ xoay của sprite
    public Animator animator;
    public Sprite[] sprite; // Mảng chứa các frame của animation 2
    public float framerate = 1f / 6f;

    private SpriteRenderer spriteRenderer;
    private int currentFrameIndex = 0; // Index của frame hiện tại
    private int frame = 0; // Index của frame hiện tại cho animation thứ hai
    private bool animation2Started = false; // Biến kiểm tra xem animation 2 đã bắt đầu chưa

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start() {
        if (sprites != null && sprites.Length > 0)
        {
            // Tính toán góc xoay mới dựa trên tốc độ và thời gian
            float newRotation = Time.deltaTime * rotationSpeed;

            // Cập nhật góc xoay của sprite
            transform.Rotate(0f, 0f, newRotation);

            if (currentFrameIndex < sprites.Length - 1)
            {
                currentFrameIndex++; // Chuyển sang frame tiếp theo
            }
            else
            {
                currentFrameIndex = 0; // Quay lại frame đầu tiên nếu đã đến frame cuối cùng
            }

            // Cập nhật sprite hiện tại
            spriteRenderer.sprite = sprites[currentFrameIndex];
        }
    }

    private void Update()
    {
        if (animation2Started)
        {
            Animate();
        }
    }

    private void Animate()
    {
        frame++;

        if (frame >= sprite.Length)
        {
            frame = 0;
        }

        if (frame >= 0 && frame < sprite.Length)
        {
            spriteRenderer.sprite = sprite[frame];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("may"))
        {
            Animate();
        }
    }
}
