using System.Collections;
using UnityEngine;


public class Gildas : MonoBehaviour
{
    public Gilda gildaData;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Timer());
    }
    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("Objeto destruido");
        Destroy(gameObject);
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    GhildaManager controller = GameObject.FindGameObjectWithTag("GhildaManager").GetComponent<GhildaManager>();

    //    if (collision.gameObject.tag == "Gilda")
    //    {
    //        Destroy(collision.gameObject);
    //        controller.puntos += 1;
    //        controller.puntosText.text = $"Puntos: {controller.puntos}";
    //    }
    //    if (collision.gameObject.tag == "GB")
    //    {
    //        Destroy(collision.gameObject);
    //        controller.puntos += 2;
    //        controller.puntosText.text = $"Puntos: {controller.puntos}";
    //        controller.IfIsGB();
    //    }
    //    if (collision.gameObject.tag == "GPQ")
    //    {
    //        Destroy(collision.gameObject);
    //        controller.puntos += 5;
    //        controller.puntosText.text = $"Puntos: {controller.puntos}";
    //        StartCoroutine(controller.IfIsGPQ());
    //    }
    //    if (collision.gameObject.tag == "GildaEngranaje")
    //    {
    //        Destroy(collision.gameObject);
    //        controller.puntos = controller.puntos/2;
    //        controller.puntosText.text = $"Puntos: {controller.puntos}";
    //    }
    //    if (collision.gameObject.tag == "GildaDestornillador")
    //    {
    //        Destroy(collision.gameObject);
    //        controller.puntos -= 1;
    //        controller.puntosText.text = $"Puntos: {controller.puntos}";
    //        StartCoroutine(controller.IfIsDestornillador());
    //    }
    //    if (collision.gameObject.tag == "GildaMartillo")
    //    {
    //        Destroy(collision.gameObject);
    //        controller.puntos -= 5;
    //        controller.puntosText.text = $"Puntos: {controller.puntos}";
    //        controller.IfIsMartillo();
    //    }
    //}
}
