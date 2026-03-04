using UnityEngine;

public class ososmalos : MonoBehaviour
{
    public GameObject prefabBala;
    public float vb = 200f;
    public int prob = 12000;
    public int nv = 1;
    public GameObject prefabExplosion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PuedeDisparar())
        {
            Disparo();
        }

    }
    public void Explosion()
    {
        GameObject explosionInstance = Instantiate(prefabExplosion, transform.position, transform.rotation);
        Destroy(explosionInstance, 0.4f);
        Destroy(gameObject);

        GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        controller.contOE += 1;
    }

   
    private void Disparo()
    {
        if(nv == 1)
        {
            GameObject balaDisparada = Instantiate(prefabBala, transform.position, Quaternion.Euler(0, 0, 180));
            Physics2D.IgnoreCollision(balaDisparada.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            Rigidbody2D balaDisparadaRigidbody2D = balaDisparada.GetComponent<Rigidbody2D>();
            balaDisparadaRigidbody2D.AddForce(Vector2.down * vb);
        }
        if (nv == 2)
        {
            Debug.Log("Disparo doble");
            float angulo = 20f;
            float separacion = 0.3f;

            Vector2 direccionIzq = Quaternion.Euler(0, 0, angulo) * Vector2.down;
            Vector2 direccionDer = Quaternion.Euler(0, 0, -angulo) * Vector2.down;

            Vector3 posIzq = transform.position + new Vector3(-separacion, 0, 0);
            Vector3 posDer = transform.position + new Vector3(separacion, 0, 0);

            GameObject bala1 = Instantiate(prefabBala, posIzq, Quaternion.identity);
            GameObject bala2 = Instantiate(prefabBala, posDer, Quaternion.identity);

            Physics2D.IgnoreCollision(bala1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(bala2.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            bala1.GetComponent<Rigidbody2D>().linearVelocity = direccionIzq * vb;
            bala2.GetComponent<Rigidbody2D>().linearVelocity = direccionDer * vb;
        }
        if (nv == 3)
        {
            Debug.Log("Disparo triple");
            float angulo = 30f;
            float separacion = 0.3f;

            Vector2 direccionIzq = Quaternion.Euler(0, 0, angulo) * Vector2.down;
            Vector2 direccionDer = Quaternion.Euler(0, 0, -angulo) * Vector2.down;
            Vector2 direccionCen = Quaternion.Euler(0, 0, 0) * Vector2.down;

            Vector3 posIzq = transform.position + new Vector3(-separacion, 0, 0);
            Vector3 posDer = transform.position + new Vector3(separacion, 0, 0);
            Vector3 posCen = transform.position + new Vector3(0, 0, 0);

            GameObject bala1 = Instantiate(prefabBala, posIzq, Quaternion.identity);
            GameObject bala2 = Instantiate(prefabBala, posDer, Quaternion.identity);
            GameObject bala3 = Instantiate(prefabBala, posCen, Quaternion.identity);

            Physics2D.IgnoreCollision(bala1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(bala2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(bala3.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            bala1.GetComponent<Rigidbody2D>().linearVelocity = direccionIzq * vb;
            bala2.GetComponent<Rigidbody2D>().linearVelocity = direccionDer * vb;
            bala2.GetComponent<Rigidbody2D>().linearVelocity = direccionCen * vb;
        }

    }
    private bool PuedeDisparar()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit.collider != null && !hit.collider.CompareTag("OM") && !hit.collider.CompareTag("OM2") && !hit.collider.CompareTag("OM3"))
        {
            return !hit.collider.CompareTag("OM") && !hit.collider.CompareTag("OM2") && !hit.collider.CompareTag("OM3") && UnityEngine.Random.Range(0, prob) == 2; // 1% de probabilidad por frame
        }
        return false;

    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gonzalo")
        {
            Debug.Log("Tendria que ser GameOver por Gonzalo");
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            controller.GameOver();
            Destroy(gameObject);
        }
       
    }
}
