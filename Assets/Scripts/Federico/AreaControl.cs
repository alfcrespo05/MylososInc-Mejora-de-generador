using UnityEngine;

public class AreaControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int cont;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RF")
        {
            Debug.Log("Recurso Dentro" + cont);
            cont++;
            if(cont > 5)
            {
                Destroy(collision.gameObject);
                Debug.Log("Recurso destruido" + cont);
                cont -= 2;
            }
        }
        if (collision.gameObject.tag == "HF")
        {
            Debug.Log("Herramienta Dentro" + cont);
            cont++;
            if (cont > 5)
            {
                Destroy(collision.gameObject);
                Debug.Log("Herramienta destruida" + cont);
                cont --;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RF")
        {
            Debug.Log("Recurso Fuera" + cont);
            cont--;
            
        }
        if (collision.gameObject.tag == "HF")
        {
            Debug.Log("Herramienta Fuera" + cont);
            cont--;

        }
    }
}
