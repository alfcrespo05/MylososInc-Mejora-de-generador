using Manager;
using UnityEngine;

public class MesaProcesadoScript : MonoBehaviour
{
    public GameObject MesaProcesado;
    public Transform SpawnMadera;
    public Transform SpawnPiedra;
    public Transform SpawnHilo;
    public GameObject MaderaPrefab;
    public GameObject PiedraPrefab;
    public GameObject HiloPrefab;
   
    [SerializeField] private GameObject botonMejora22;
    [SerializeField] private GameObject botonMejora32;
    [SerializeField] private GameObject botonMejora42;
    [SerializeField] private GameObject botonMejora52;
    [SerializeField] private GameObject botonMejoraMaxima2;
    [SerializeField] private GameObject botonDestruir;
    [SerializeField] private GameObject botonAtras;
    public UIManager1 mejoraUI;

    public float timer;
    public bool procesando;
    float tiempo;

    void Start()
    {
        procesando = false;
        tiempo = 5;
        botonMejora22.SetActive(true);
        botonMejora32.SetActive(false);
        botonMejora42.SetActive(false);
        botonMejora52.SetActive(false);
        botonMejoraMaxima2.SetActive(false);
  
    }

    void Update()
    {
        if (procesando == true)
        {
            Process();
        }
    }

    private void Process()
    {
        timer += Time.deltaTime;

        if (timer >= tiempo)
        {
            timer = 0;

            if (transform.tag == "MesaProcesadoMadera")
            {
                Instantiate(MaderaPrefab, SpawnMadera.position, SpawnMadera.rotation);
            }
            else if (transform.tag == "MesaProcesadoPiedra")
            {
                Instantiate(PiedraPrefab, SpawnPiedra.position, SpawnPiedra.rotation);
            }
            else if (transform.tag == "MesaProcesadoHilo")
            {
                Instantiate(HiloPrefab, SpawnHilo.position, SpawnHilo.rotation);
            }

            procesando = false;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ecocombustible")
        {
            if (procesando == false)
            {
                Destroy(collision.gameObject);
                procesando = true;
            }
            
        }
    }
    public void nivelDos()
    {
        if (GameManager.Instance.totalMadera >= 1 && GameManager.Instance.totalPiedra >= 1)
        {
            GameManager.Instance.LowerTotalMadera(1);
            GameManager.Instance.LowerTotalPiedra(1);
            botonMejora22.SetActive(false);
            botonMejora32.SetActive(true);
            botonMejora42.SetActive(false);
            botonMejora52.SetActive(false);
            botonMejoraMaxima2.SetActive(false);
            tiempo = 3.5f;
     
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
            botonMejora22.SetActive(false);
            botonMejora32.SetActive(false);
            botonMejora42.SetActive(true);
            botonMejora52.SetActive(false);
            botonMejoraMaxima2.SetActive(false);
            tiempo = 2.7f;
            timer += Time.deltaTime;
         


            if (timer >= tiempo)
            {
                timer = 0;

                if (transform.tag == "MesaProcesadoMadera")
                {
                    Instantiate(MaderaPrefab, SpawnMadera.position, SpawnMadera.rotation);
                }
                else if (transform.tag == "MesaProcesadoPiedra")
                {
                    Instantiate(PiedraPrefab, SpawnPiedra.position, SpawnPiedra.rotation);
                }
                else if (transform.tag == "MesaProcesadoHilo")
                {
                    Instantiate(HiloPrefab, SpawnHilo.position, SpawnHilo.rotation);
                }

                procesando = false;
            }

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
            botonMejora22.SetActive(false);
            botonMejora32.SetActive(false);
            botonMejora42.SetActive(false);
            botonMejora52.SetActive(true);
            botonMejoraMaxima2.SetActive(false);
            tiempo = 1.6f;
            timer += Time.deltaTime;
    


            if (timer >= tiempo)
            {
                timer = 0;

                if (transform.tag == "MesaProcesadoMadera")
                {
                    Instantiate(MaderaPrefab, SpawnMadera.position, SpawnMadera.rotation);
                }
                else if (transform.tag == "MesaProcesadoPiedra")
                {
                    Instantiate(PiedraPrefab, SpawnPiedra.position, SpawnPiedra.rotation);
                }
                else if (transform.tag == "MesaProcesadoHilo")
                {
                    Instantiate(HiloPrefab, SpawnHilo.position, SpawnHilo.rotation);
                }

                procesando = false;
            }

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
            botonMejora22.SetActive(false);
            botonMejora32.SetActive(false);
            botonMejora42.SetActive(false);
            botonMejora52.SetActive(false);
            botonMejoraMaxima2.SetActive(true);
            tiempo = 1.0f;
            timer += Time.deltaTime;
 


            if (timer >= tiempo)
            {
                timer = 0;

                if (transform.tag == "MesaProcesadoMadera")
                {
                    Instantiate(MaderaPrefab, SpawnMadera.position, SpawnMadera.rotation);
                }
                else if (transform.tag == "MesaProcesadoPiedra")
                {
                    Instantiate(PiedraPrefab, SpawnPiedra.position, SpawnPiedra.rotation);
                }
                else if (transform.tag == "MesaProcesadoHilo")
                {
                    Instantiate(HiloPrefab, SpawnHilo.position, SpawnHilo.rotation);
                }

                procesando = false;
            }

        }
        else
        {
            Debug.Log("No tienes materiales");
        }
    }
    private void OnMouseDown()
    {

        Vector3 posPantalla = Camera.main.WorldToScreenPoint(transform.position);
        mejoraUI.MostrarPanel2(posPantalla);
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
