using UnityEngine;

public class BordeEliminado : MonoBehaviour
{
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
        if (collision.gameObject.tag == "FedeMadera")
        {
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.vidas -= 1;
        }
        if (collision.gameObject.tag == "FedeHilo")
        {
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.vidas -= 1;
        }
        if (collision.gameObject.tag == "FedePiedra")
        {
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.vidas -= 1;
        }
        if (collision.gameObject.tag == "FedeEco")
        {
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.vidas -= 1;
        }
        if (collision.gameObject.tag == "CabezaFede")
        {
            GAmeController controller = GameObject.FindGameObjectWithTag("GAmecontroller").GetComponent<GAmeController>();
            controller.vidas -= 1;
        }
    }
}
