using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] float velocidad;
    enum Direccion { Arriba, Derecha, Abajo, Izquierda};

    Direccion direccion = Direccion.Arriba;

    [SerializeField] float distancia;
    [SerializeField] public float frecuencia = 0.25f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("movimiento", 0.5f, frecuencia);
        direccion = Direccion.Arriba;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.Translate(Vector2.up * velocidad * Time.deltaTime);
            if(direccion != Direccion.Abajo)
            {
                direccion = Direccion.Arriba;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.Translate(Vector2.down * velocidad * Time.deltaTime);
            if (direccion != Direccion.Arriba)
            {
                direccion = Direccion.Abajo;
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            if (direccion != Direccion.Derecha)
            {
                direccion = Direccion.Izquierda;
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            if (direccion != Direccion.Izquierda)
            {
                direccion = Direccion.Derecha;
                transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            }
        }
    }
    public void movimiento()
    {
        switch (direccion)
        {
            case Direccion.Arriba:
                transform.Translate(Vector2.up * distancia, Space.World);
                break;
            case Direccion.Derecha:
                transform.Translate(Vector2.right * distancia, Space.World);
                break;
            case Direccion.Abajo:
                transform.Translate(Vector2.down * distancia, Space.World);
                break;
            case Direccion.Izquierda:
                transform.Translate(Vector2.left * distancia, Space.World);
                break;


        }
    }
    
}
