using UnityEngine;

public class OsoMovement : MonoBehaviour
{
    public float speed;

    public AudioClip Sound;
    private Rigidbody2D rb;
    private Vector2 direction = new Vector2(0, 0);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed * Time.deltaTime;
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }
}
