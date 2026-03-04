using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Recursos : MonoBehaviour
{

    //public bool activado;
    
    public Recurso recursoData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border Eliminado")
        {
            Destroy(gameObject);
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();

        }
    }



}
