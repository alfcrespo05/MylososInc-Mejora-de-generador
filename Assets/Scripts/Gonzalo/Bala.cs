using UnityEngine;

public class Bala : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
      
  
    }

 

    private void DestruirOso(Collision2D collision)
    {
        ososmalos ososmalos = collision.gameObject.GetComponent<ososmalos>();
        ososmalos.Explosion();
    }
    //private void DestruirJugador(Collision2D collision)
    //{
    //    Gonzalo gonzalo = collision.gameObject.GetComponent<Gonzalo>();
    //    gonzalo.Explotar();
    //}
    private bool IsOso(Collision2D collision) => collision.gameObject.tag == "OM";
    private bool IsOso2(Collision2D collision) => collision.gameObject.tag == "OM2";
    private bool IsOso3(Collision2D collision) => collision.gameObject.tag == "OM3";
    //private bool IsJugador(Collision2D collision) => collision.gameObject.tag == "Gonzalo";

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (IsOso(collision))
        {
            DestruirOso(collision);
            Destroy(gameObject);
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            controller.ososRestantes1 += 1;
        }
        if (IsOso2(collision))
        {
            DestruirOso(collision);
            Destroy(gameObject);
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            controller.ososRestantes2 += 1;
        }
        if (IsOso3(collision))
        {
            DestruirOso(collision);
            Destroy(gameObject);
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            controller.ososRestantes3 += 1;
        }
        if (collision.gameObject.tag == "SCGO")
        {
            Destroy(gameObject);
        }
       
      

    }
 
}
