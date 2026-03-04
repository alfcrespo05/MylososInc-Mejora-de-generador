using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] public int vidas = 2;
   
    public int contTiros;
    public int contOE;
    public int contRo;

    public GameObject prefabJugador;

    public GameObject ososContainer;

    public int ososRestantes1 = 0;
    public int ososRestantes2 = 0;
    public int ososRestantes3 = 0;


    [SerializeField] private GameObject botonPausa1;
    [SerializeField] private GameObject botonPausa2;
    [SerializeField] private GameObject botonPausa3;
    [SerializeField] private GameObject Resume1;
    [SerializeField] private GameObject Resume2;
    [SerializeField] private GameObject Resume3;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject barran1;
    [SerializeField] private GameObject barran2;
    [SerializeField] private GameObject barran3;
    [SerializeField] private GameObject TileMap1;
    [SerializeField] private GameObject TileMap2;
    [SerializeField] private GameObject TileMap3;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject vida1;
    [SerializeField] private GameObject vida2;
    [SerializeField] private GameObject FilaOso1;
    [SerializeField] private GameObject FilaOso2;
    [SerializeField] private GameObject FilaOso3;
    [SerializeField] private GameObject OsosMalos1;
    [SerializeField] private GameObject OsosMalos2;
    [SerializeField] private GameObject OsosMalos3;

    public GameObject Fila3;
    private bool UI1 = true;
    private bool UI2 = false;
    private bool UI3 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contTiros = 0;
        contOE = 0;
        contRo = 0;

        

        vidas = 2;
        
        botonPausa1.SetActive(true);
        botonPausa2.SetActive(false);
        botonPausa3.SetActive(false);

        Resume1.SetActive(false);
        Resume2.SetActive(false);
        Resume3.SetActive(false);

        menuPausa.SetActive(false);

        barran1.SetActive(true);
        barran2.SetActive(false);
        barran3.SetActive(false);

        TileMap1.SetActive(true);
        TileMap2.SetActive(false);
        TileMap3.SetActive(false);

        vida1.SetActive(true);
        vida2.SetActive(true);

        FilaOso1.SetActive(true);
        FilaOso2.SetActive(false);
        FilaOso3.SetActive(false);

        OsosMalos1.SetActive(true);
        OsosMalos2.SetActive(false);
        OsosMalos3.SetActive(false);

        Time.timeScale = 1;

      

        SpawnJugador();

    }

    private void Update()
    {
       

        if (vidas == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
          
        }
        if (vidas == 0)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
           
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ContarVidas();
        Recompensas();
        Niveles();
    }
  
    private void SpawnJugador()
    {
        Instantiate(prefabJugador, new Vector3(0, -3 , 0), Quaternion.Euler(0, 0, 0));
    }
    public void RestarVida()
    {
        vidas -= 1;
       
        if (vidas != 0)
        {
            SpawnJugador();
        }
    }
    public void RestarVida2()
    {
        vidas -= 2;

    }
    //public void mirarOsos()
    //{
    //    Collider2D ososContainerCollider = ososContainer.GetComponent<Collider2D>();
    //    ContactFilter2D filter = new ContactFilter2D();
    //    filter.SetLayerMask(LayerMask.GetMask("OM"));
    //    List<Collider2D> resultados = new List<Collider2D>();
    //    int ososRestantes1 = Physics2D.OverlapCollider(ososContainerCollider, filter, resultados);
    //}
    public void ContarVidas()
    {
        if(vidas <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
    
            Time.timeScale = 0;
            gameOverUI.SetActive(true);

            menuPausa.SetActive(false);

            Resume1.SetActive(false);
            Resume2.SetActive(false);
            Resume3.SetActive(false);
        if(UI1 == true)
        {
            barran1.SetActive(true);
            TileMap1.SetActive(true);
            botonPausa1.SetActive(true);
        }
        if (UI2 == true)
        {
            barran2.SetActive(true);
            TileMap2.SetActive(true); 
            botonPausa2.SetActive(true);
        }
        if (UI3 == true)
        {
            barran3.SetActive(true);
            TileMap3.SetActive(true);
            botonPausa3.SetActive(true);
        }
    }
    
    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
    public void Niveles()
    {
     
        if (ososRestantes1 >= 40)//40
        {
            botonPausa1.SetActive(false);
            botonPausa2.SetActive(true);
            botonPausa3.SetActive(false);

            menuPausa.SetActive(false);

            barran1.SetActive(false);
            barran2.SetActive(true);
            barran3.SetActive(false);


            TileMap1.SetActive(false);
            TileMap2.SetActive(true);
            TileMap3.SetActive(false);

            FilaOso1.SetActive(false);
            FilaOso2.SetActive(true);
            FilaOso3.SetActive(false);

            OsosMalos1.SetActive(false);
            OsosMalos2.SetActive(true);
            OsosMalos3.SetActive(false);
            UI1 = false;
            UI2 = true;
            UI3 = false;

        }
        if (ososRestantes2 >= 48)//48
        {
            botonPausa1.SetActive(false);
            botonPausa2.SetActive(false);
            botonPausa3.SetActive(true);

            menuPausa.SetActive(false);

            barran1.SetActive(false);
            barran2.SetActive(false);
            barran3.SetActive(true);


            TileMap1.SetActive(false);
            TileMap2.SetActive(false);
            TileMap3.SetActive(true);

            FilaOso1.SetActive(false);
            FilaOso2.SetActive(false);
            FilaOso3.SetActive(true);

            OsosMalos1.SetActive(false);
            OsosMalos2.SetActive(false);
            OsosMalos3.SetActive(true);

            UI1 = false;
            UI2 = false;
            UI3 = true;

        }
        if (ososRestantes3 >= 42)//42
        {
            botonPausa1.SetActive(false);
            botonPausa2.SetActive(false);
            botonPausa3.SetActive(true);

            menuPausa.SetActive(false);

            barran1.SetActive(false);
            barran2.SetActive(false);
            barran3.SetActive(true);


            TileMap1.SetActive(false);
            TileMap2.SetActive(false);
            TileMap3.SetActive(true);

            FilaOso1.SetActive(false);
            FilaOso2.SetActive(false);
            FilaOso3.SetActive(true);

            OsosMalos1.SetActive(false);
            OsosMalos2.SetActive(false);
            OsosMalos3.SetActive(true);

            UI1 = false;
            UI2 = false;
            UI3 = true;

        }
    }
    public void Recompensas()
    {
        if (ososRestantes1 == 40)
        {
            //9 de cada recurso o 5 de cada recurso y un objeto para colocar en la casa
           
            ososRestantes1 = 45;
        }
        if (ososRestantes2 == 48)
        {
            //45 de cada recurso o 25 de cada recurso y un objeto para colocar en la casa
           
            ososRestantes2 = 53;
        }
        if (ososRestantes3 == 42)
        {
            //170 de cada recurso o 70 de cada recurso y un objeto para colocar en la casa
            contRo += 1;
            ososRestantes3 = 0;
            Instantiate(Fila3, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            Vector3 Pos = new Vector3(0, -3, 0);
            prefabJugador.transform.position = Pos;
         
        }
        if (contRo == 10)
        {
            //figura de oro del personaje que podrá colocar entro o fuera de la casa
        }
        if (contTiros == contOE)
        {
            //objeto especial que se podrá colocar dentro o fuera de la casa
        }

    }
    public void BotonPausa1()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else Time.timeScale = 1;
        botonPausa1.SetActive(false);
        botonPausa2.SetActive(false);
        botonPausa3.SetActive(false);

        menuPausa.SetActive(true);


        Resume1.SetActive(true);
        Resume2.SetActive(false);
        Resume3.SetActive(false);

        if (UI1 == true)
        {
            barran1.SetActive(true);
            TileMap1.SetActive(true);
            
        }
        if (UI2 == true)
        {
            barran2.SetActive(true);
            TileMap2.SetActive(true);
            
        }
        if (UI3 == true)
        {
            barran3.SetActive(true);
            TileMap3.SetActive(true);
           
        }
    }
    public void BotonPausa2()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else Time.timeScale = 1;
        botonPausa1.SetActive(false);
        botonPausa2.SetActive(false);
        botonPausa3.SetActive(false);

        menuPausa.SetActive(true);

        Resume1.SetActive(false);
        Resume2.SetActive(true);
        Resume3.SetActive(false);

        if (UI1 == true)
        {
            barran1.SetActive(true);
            TileMap1.SetActive(true);

        }
        if (UI2 == true)
        {
            barran2.SetActive(true);
            TileMap2.SetActive(true);

        }
        if (UI3 == true)
        {
            barran3.SetActive(true);
            TileMap3.SetActive(true);

        }
    }
    public void BotonPausa3()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else Time.timeScale = 1;
        botonPausa1.SetActive(false);
        botonPausa2.SetActive(false);
        botonPausa3.SetActive(false);

        menuPausa.SetActive(true);


        Resume1.SetActive(false);
        Resume2.SetActive(false);
        Resume3.SetActive(true);

        if (UI1 == true)
        {
            barran1.SetActive(true);
            TileMap1.SetActive(true);

        }
        if (UI2 == true)
        {
            barran2.SetActive(true);
            TileMap2.SetActive(true);

        }
        if (UI3 == true)
        {
            barran3.SetActive(true);
            TileMap3.SetActive(true);

        }
    }
    public void Reanudar1()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else Time.timeScale = 0;
        botonPausa1.SetActive(true);
        botonPausa2.SetActive(false);
        botonPausa3.SetActive(false);

        menuPausa.SetActive(false);

        barran1.SetActive(true);
        barran2.SetActive(false);
        barran3.SetActive(false);


        TileMap1.SetActive(true);
        TileMap2.SetActive(false);
        TileMap3.SetActive(false);
    }
    public void Reanudar2()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else Time.timeScale = 0;
        botonPausa1.SetActive(false);
        botonPausa2.SetActive(true);
        botonPausa3.SetActive(false);

        menuPausa.SetActive(false);

        barran1.SetActive(false);
        barran2.SetActive(true);
        barran3.SetActive(false);


        TileMap1.SetActive(false);
        TileMap2.SetActive(true);
        TileMap3.SetActive(false);
    }
    public void Reanudar3()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else Time.timeScale = 0;
        botonPausa1.SetActive(false);
        botonPausa2.SetActive(false);
        botonPausa3.SetActive(true);

        menuPausa.SetActive(false);

        barran1.SetActive(false);
        barran2.SetActive(false);
        barran3.SetActive(true);


        TileMap1.SetActive(false);
        TileMap2.SetActive(false);
        TileMap3.SetActive(true);
    }
    public void BotonSalir()
    {
        SceneManager.LoadScene(1);
    }
    public void BotonReiniciar()
    {
        SceneManager.LoadScene(4);
    }

}
