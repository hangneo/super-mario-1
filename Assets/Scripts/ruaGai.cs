using UnityEditor;
using UnityEngine;

public class ruaGai : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction = Vector2.left;

    private new Rigidbody2D rigidbody;
    private Vector2 velocity;
    public Animator amt;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    private void Start()
    {
        amt = GetComponent<Animator>();
        amt.SetBool("isRunning", false);
    }

    private void OnBecameVisible()
    {
        #if UNITY_EDITOR
        enabled = !EditorApplication.isPaused;
        #else
        enabled = true;
        #endif
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        rigidbody.WakeUp();
    }

    private void OnDisable()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.Sleep();
    }

    private void FixedUpdate()
    {
        velocity.x = direction.x * speed;
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);

        if (rigidbody.Raycast(direction)) {
            direction = -direction;
        }

        if (rigidbody.Raycast(Vector2.down)) {
            velocity.y = Mathf.Max(velocity.y, 0f);
        }

        if (direction.x > 0f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (direction.x < 0f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.starpower)
            {
                Hit();
            }
            else
            {
                player.Hit_();
            }
        }
        if (!collision.gameObject.CompareTag("may"))
        {
            amt.SetBool("isRunning", true);
        }
        if (collision.gameObject.CompareTag("test"))
        {
        }
    }

    private void Hit()
    {
        amt.SetBool("death", true);
        GetComponent<DeathAnimation>().enabled = true;
        Destroy(gameObject, 1f);
    }
}
