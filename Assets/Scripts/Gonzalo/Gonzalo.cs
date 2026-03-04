using JetBrains.Annotations;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace System.Collections.Generic
{
    public interface IEnumerables<T> {}
}

public class Gonzalo : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    Vector2 movimiento;
    public GameObject prefabBala;

    public float cadencia = 0.8f;

    public float velocidadDisparo = 600f;

    private float siguienteDisparo = 0f;

    public GameObject explosion;

    public float immortalidadDuracion = 1f;

    void Start()
    {
        //StartCoroutine(TemporalImmortalityCoroutine());

       rb = GetComponent<Rigidbody2D>();
      

        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        if(PuedeDisparar())
            Disparo();
    }
    void Movimiento()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + movimiento * velocidad);
    }
    private bool PuedeDisparar() => Input.GetButton("Fire1") && Time.time > siguienteDisparo;

    private void Disparo()
    {
        GameObject balaDisparada = Instantiate(prefabBala, transform.position, transform.rotation);
        GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        controller.contTiros += 1;
        Rigidbody2D balaDisparadaRigidBody2D = balaDisparada.GetComponent<Rigidbody2D>();
        balaDisparadaRigidBody2D.AddForce(Vector3.up * velocidadDisparo);

        Physics2D.IgnoreCollision(balaDisparada.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        siguienteDisparo = Time.time + cadencia;
    }
    public void Explotar()
    {
        GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosionInstance, 0.4f);
        Destroy(gameObject);

        GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        controller.RestarVida();
    }
    public void Explotar2()
    {
        GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(explosionInstance, 0.4f);
        Destroy(gameObject);

        GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        controller.RestarVida2();
    }

    //IEnumerables<float> TemporalImmortalityCoroutine()
    //{


    //    float startTime = Time.time;

    //    GetComponent<Collider2D>().enabled = false;
    //    GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);

    //    yield return new WaitForSeconds(immortalidadDuracion);

    //    GetComponent<Collider2D>().enabled = true;
    //    GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    //}
}
