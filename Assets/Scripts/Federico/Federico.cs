using UnityEngine;

public class Federico : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    Vector2 movimiento;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }
    void Movimiento()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movimiento * velocidad);
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FedeMadera")
        {
            Destroy(collision.gameObject);
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.puntos += 1;
            controller.pointsLeftText.text = $"Puntos: {controller.puntos}";
        }
        if (collision.gameObject.tag == "FedeHilo")
        {
            Destroy(collision.gameObject);
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.puntos += 1;
            controller.pointsLeftText.text = $"Puntos: {controller.puntos}";
        }
        if (collision.gameObject.tag == "FedePiedra")
        {
            Destroy(collision.gameObject);
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.puntos += 1;
            controller.pointsLeftText.text = $"Puntos: {controller.puntos}";
        }
        if (collision.gameObject.tag == "FedeEco")
        {
            Destroy(collision.gameObject);
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.puntos += 2;
            controller.pointsLeftText.text = $"Puntos: {controller.puntos}";
        }
        if (collision.gameObject.tag == "CabezaFede")
        {
            Destroy(collision.gameObject);
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.puntos += 5;
            controller.pointsLeftText.text = $"Puntos: {controller.puntos}";
        }
        if (collision.gameObject.tag == "FedeEngranaje")
        {
            Destroy(collision.gameObject);
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.puntos = controller.puntos/2;
            if (controller.puntos <= 0)
            {
                controller.puntos = 0;
            }
            controller.pointsLeftText.text = $"Puntos: {controller.puntos}";
            controller.vidas -= 2;
        }
        if (collision.gameObject.tag == "FedeDestornillador")
        {
            Destroy(collision.gameObject);
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.puntos -= 1;
            if (controller.puntos <= 0)
            {
                controller.puntos = 0;
            }
            controller.pointsLeftText.text = $"Puntos: {controller.puntos}";
            controller.vidas -= 1;
        }
        if (collision.gameObject.tag == "FedeMartillo")
        {
            Destroy(collision.gameObject);
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.puntos -= 5;
            if (controller.puntos <= 0)
            {
                controller.puntos = 0;
            }
            controller.pointsLeftText.text = $"Puntos: {controller.puntos}";
            controller.vidas -= 1;
        }
    }


}
