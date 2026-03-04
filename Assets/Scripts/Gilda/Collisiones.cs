    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class Collisiones : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Debug.Log("GameOver");
            GhildaManager controller = GameObject.FindGameObjectWithTag("GhildaManager").GetComponent<GhildaManager>();
            controller.GameOver();
        }
        if (collision.CompareTag("Gilda"))
        {
            GhildaManager controller = GameObject.FindGameObjectWithTag("GhildaManager").GetComponent<GhildaManager>();
            Destroy(collision.gameObject);
            controller.SumarPuntos(1);
            controller.Comido();
        }
        if (collision.CompareTag("GB"))
        {
            GhildaManager controller = GameObject.FindGameObjectWithTag("GhildaManager").GetComponent<GhildaManager>();

            Destroy(collision.gameObject);

            controller.ActivarBuffGB();   
            controller.SumarPuntos(2);    

            controller.Comido();
        }
        if (collision.CompareTag("GPQ"))
        {
            GhildaManager controller = GameObject.FindGameObjectWithTag("GhildaManager").GetComponent<GhildaManager>();
         
            Destroy(collision.gameObject);
            controller.SumarPuntos(5);
            StartCoroutine(controller.IfIsGPQ());
            controller.Comido();
        }
        if (collision.CompareTag("GildaDestornillador"))
        {
            GhildaManager controller = GameObject.FindGameObjectWithTag("GhildaManager").GetComponent<GhildaManager>();
           
            Destroy(collision.gameObject);
            controller.SumarPuntos(-1);
            if (controller.puntos <= 0)
            {
                controller.puntos = 0;
            }
            StartCoroutine(controller.IfIsDestornillador());
            controller.Comido();
        }
        if (collision.CompareTag("GildaMartillo"))
        {
            GhildaManager controller = GameObject.FindGameObjectWithTag("GhildaManager").GetComponent<GhildaManager>();
            Destroy(collision.gameObject);
            controller.SumarPuntos(-5);
            if (controller.puntos <= 0)
            {
                controller.puntos = 0;
            }
            controller.IfIsMartillo();
            controller.Comido();
        }
        if (collision.CompareTag("GildaEngranaje"))
        {
            GhildaManager controller = GameObject.FindGameObjectWithTag("GhildaManager").GetComponent<GhildaManager>();
            Destroy(collision.gameObject);
            int mitad = controller.puntos / 2;
            int resta = mitad - controller.puntos;  
            controller.SumarPuntos(resta);
            if (controller.puntos <= 0)
            {
                controller.puntos = 0;
            }
            controller.Comido();
        }
    }
}





    
    

    
            

                



        
        
  

    
