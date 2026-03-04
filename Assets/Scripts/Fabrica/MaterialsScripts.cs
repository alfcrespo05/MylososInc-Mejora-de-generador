using UnityEngine;

public class MaterialsScripts : MonoBehaviour
{
    public float speed;

    public AudioClip Sound;
    private Rigidbody2D rb;
    private Vector2 direction = new Vector2(6, 0);

    //public Vector2 CurrentVelocity => rb.linearVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
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


