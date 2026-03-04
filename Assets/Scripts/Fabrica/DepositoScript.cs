
using Manager;

using UnityEngine;

public class DepositoScript : MonoBehaviour
{
    public UIManager1 UIManager;
    public GameObject Deposito;
    public GameObject MaterialFinalPrefab;
  
    [SerializeField] private GameObject botonMejora21;
    [SerializeField] private GameObject botonMejora31;
    [SerializeField] private GameObject botonMejora41;
    [SerializeField] private GameObject botonMejora51;
    [SerializeField] private GameObject botonMejoraMaxima1;
    [SerializeField] private GameObject botonDestruir;
    [SerializeField] private GameObject botonAtras;
    public UIManager1 mejoraUI;
    public int cap;
    public int lim;
    void Start()
    {

        botonMejora21.SetActive(true);
        botonMejora31.SetActive(false);
        botonMejora41.SetActive(false);
        botonMejora51.SetActive(false);
        botonMejoraMaxima1.SetActive(false);
       

        lim = 20;
        
    }
    private void Update()
    {
        cap = lim;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.tag == "Madera")
        {
            Destroy(collision.gameObject);
            
            if (GameManager.Instance.totalMadera > cap)
            {
                GameManager.Instance.totalMadera = cap;
            }
            else if (GameManager.Instance.totalMadera < cap)
            {
                GameManager.Instance.RaiseTotalMadera(1);
            }

        }
        else if (collision.transform.tag == "Piedra")
        {
            Destroy(collision.gameObject);
           
            if (GameManager.Instance.totalPiedra > cap)
            {
                GameManager.Instance.totalPiedra = cap;
            }
            else if(GameManager.Instance.totalPiedra < cap)
            {
                GameManager.Instance.RaiseTotalPiedra(1);
            }
        }
        else if (collision.transform.tag == "Hilo")
        {
            Destroy(collision.gameObject);
          
            if (GameManager.Instance.totalHilo > cap)
            {
                GameManager.Instance.totalHilo = cap;
            }
            else if(GameManager.Instance.totalHilo < cap)
            {
                GameManager.Instance.RaiseTotalHilo(1);
            }
        }

    }
    public void nivelDos()
    {

       
        if (GameManager.Instance.totalMadera >= 1 && GameManager.Instance.totalPiedra >= 1)
        {
            GameManager.Instance.LowerTotalMadera(1);
            GameManager.Instance.LowerTotalPiedra(1);
            botonMejora21.SetActive(false);
            botonMejora31.SetActive(true);
            botonMejora41.SetActive(false);
            botonMejora51.SetActive(false);
            botonMejoraMaxima1.SetActive(false);
            lim = 50;
         
        }
        else
        {
            Debug.Log("No tienes materiales");
        }
    }
    public void nivelTres()
    {

       
        if (GameManager.Instance.totalMadera >= 1 && GameManager.Instance.totalPiedra >= 1)
        {
            GameManager.Instance.LowerTotalMadera(1);
            GameManager.Instance.LowerTotalPiedra(1);
            botonMejora21.SetActive(false);
            botonMejora31.SetActive(false);
            botonMejora41.SetActive(true);
            botonMejora51.SetActive(false);
            botonMejoraMaxima1.SetActive(false);
            lim = 130;
     
        }
        else
        {
            Debug.Log("No tienes materiales");
        }
    }
    public void nivelCuatro()
    {

        
        if (GameManager.Instance.totalMadera >= 1 && GameManager.Instance.totalPiedra >= 1)
        {
            GameManager.Instance.LowerTotalMadera(1);
            GameManager.Instance.LowerTotalPiedra(1);
            botonMejora21.SetActive(false);
            botonMejora31.SetActive(false);
            botonMejora41.SetActive(false);
            botonMejora51.SetActive(true);
            botonMejoraMaxima1.SetActive(false);
            lim = 200;
   
        }
        else
        {
            Debug.Log("No tienes materiales");
        }
    }
    public void nivelCinco()
    {

       
        if (GameManager.Instance.totalMadera >= 1 && GameManager.Instance.totalPiedra >= 1)
        {
            GameManager.Instance.LowerTotalMadera(1);
            GameManager.Instance.LowerTotalPiedra(1);
            botonMejora21.SetActive(false);
            botonMejora31.SetActive(false);
            botonMejora41.SetActive(false);
            botonMejora51.SetActive(false);
            botonMejoraMaxima1.SetActive(true);
            lim = 500;

        }
        else
        {
            Debug.Log("No tienes materiales");
        }
    }
    private void OnMouseDown()
    {

        Vector3 posPantalla = Camera.main.WorldToScreenPoint(transform.position);
        mejoraUI.MostrarPanel1(posPantalla);
    }
    public void BotonDestruir()
    {
        mejoraUI.OcultarPanel();
        Destroy(gameObject);
    }
    public void BotonAtras()
    {
        mejoraUI.OcultarPanel();
    }


}



