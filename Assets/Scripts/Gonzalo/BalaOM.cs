
using UnityEngine;

public class BalaOM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //CheckMouseClickDown();

    }



    //private void DestruirOso(Collision2D collision)
    //{
    //    ososmalos ososmalos = collision.gameObject.GetComponent<ososmalos>();
    //    ososmalos.Explosion();
    //}
    private void DestruirJugador(Collider2D collision)
    {
        Gonzalo gonzalo = collision.gameObject.GetComponent<Gonzalo>();
        gonzalo.Explotar();
    }
    //private bool IsOso(Collider2D collision) => collision.gameObject.tag == "OM";
    //private bool IsOso2(Collider2D collision) => collision.gameObject.tag == "OM";
    //private bool IsOso3(Collider2D collision) => collision.gameObject.tag == "OM";
    private bool IsJugador(Collider2D collision) => collision.gameObject.tag == "Gonzalo";

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if (IsOso(collision))
        //{
        //    Destroy(gameObject);
        //}
        //if (IsOso2(collision))
        //{
        //    Destroy(gameObject);
        //}
        //if (IsOso3(collision))
        //{
        //    Destroy(gameObject);
        //}
        if (IsJugador(collision))
        {
            DestruirJugador(collision);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "SCGO")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BalaGO")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Han chocado dos balas");
        }

    }
  

   
}
