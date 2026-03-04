using JetBrains.Annotations;
using Manager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GeneradorScript : MonoBehaviour
{
    public GameObject Generador;
    public Transform SpawnEcocombustible;
    public GameObject EcocombustiblePrefab;
    public SpawnBlockDetector SpawnBlockDetector;
    public UIManager1 UIManager;
    [SerializeField] private GameObject botonMejora2;
    [SerializeField] private GameObject botonMejora3;
    [SerializeField] private GameObject botonMejora4;
    [SerializeField] private GameObject botonMejora5;
    [SerializeField] private GameObject botonMejoraMaxima;
   
    [SerializeField] private GameObject botonDestruir;
    [SerializeField] private GameObject botonAtras;
    public UIManager1 mejoraUI;

    public float timer;
    public float timer2 = 3.0f;
    float tiempo;
    
    //private float LastDrop;

    void Start()
    {
        tiempo = 3;
        botonMejora2.SetActive(true);
        botonMejora3.SetActive(false);
        botonMejora4.SetActive(false);
        botonMejora5.SetActive(false);
        botonMejoraMaxima.SetActive(false);
    

    }

    private void Update()
    {
        Drop();
     
        
    }

    private void Drop()
    {
       
        timer += Time.deltaTime;
        timer2 -= Time.deltaTime;
        if (timer >= tiempo)
        {
            timer = 0;
            
            if (SpawnBlockDetector.bloqueado == false)
            {
                if(timer2 <= 0)
                {
                    timer2 = 3;
                    Instantiate(EcocombustiblePrefab, SpawnEcocombustible.position, SpawnEcocombustible.rotation);
                }
               
            }
            else
            {
                Debug.Log("Spawn bloqueado esperando a que se libere");
            }

        }
        


    }
    public void nivelDos()
    {
        if (GameManager.Instance.totalMadera >= 1 && GameManager.Instance.totalPiedra >= 1)
        {
            GameManager.Instance.LowerTotalMadera(1);
            GameManager.Instance.LowerTotalPiedra(1);
            botonMejora2.SetActive(false);
            botonMejora3.SetActive(true);
            botonMejora4.SetActive(false);
            botonMejora5.SetActive(false);
            botonMejoraMaxima.SetActive(false);
            tiempo = 2.5f;
       


        }
      
    }
    public void nivelTres()
    {
        if (GameManager.Instance.totalMadera >= 1 && GameManager.Instance.totalPiedra >= 1)
        {
            GameManager.Instance.LowerTotalMadera(1);
            GameManager.Instance.LowerTotalPiedra(1);
            botonMejora2.SetActive(false);
            botonMejora3.SetActive(false);
            botonMejora4.SetActive(true);
            botonMejora5.SetActive(false);
            botonMejoraMaxima.SetActive(false);
            tiempo = 2.0f;
            timer += Time.deltaTime;
          

        }
       
    }
    public void nivelCuatro()
    {
        if (GameManager.Instance.totalMadera >= 1 && GameManager.Instance.totalPiedra >= 1)
        {
            GameManager.Instance.LowerTotalMadera(1);
            GameManager.Instance.LowerTotalPiedra(1);
            botonMejora2.SetActive(false);
            botonMejora3.SetActive(false);
            botonMejora4.SetActive(false);
            botonMejora5.SetActive(true);
            botonMejoraMaxima.SetActive(false);
            tiempo = 1.5f;
            timer += Time.deltaTime;
         

        }
  
    }
    public void nivelCinco()
    {
        if (GameManager.Instance.totalMadera >= 1 && GameManager.Instance.totalPiedra >= 1)
        {
            GameManager.Instance.LowerTotalMadera(1);
            GameManager.Instance.LowerTotalPiedra(1);
            botonMejora2.SetActive(false);
            botonMejora3.SetActive(false);
            botonMejora4.SetActive(false);
            botonMejora5.SetActive(false);
            botonMejoraMaxima.SetActive(true);
            tiempo = 0.5f;
            timer += Time.deltaTime;
       
        }
    
    }
    private void OnMouseDown()
    {
        
        Vector3 posPantalla = Camera.main.WorldToScreenPoint(transform.position);
        mejoraUI.MostrarPanel(posPantalla);
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
