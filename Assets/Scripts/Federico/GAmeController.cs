using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAmeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Recursos> Recursos;
    List<Recursos> rec_vidas = new List<Recursos>();
    [SerializeField] public int puntos = 0;
    [SerializeField] public int vidas = 3;
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
    [SerializeField] private GameObject vida1;
    [SerializeField] private GameObject vida2;
    [SerializeField] private GameObject vida3;

    int prob = 150;
    int contCF = 0;
    int pos;

    private bool UI1 = true;
    private bool UI2 = false;
    private bool UI3 = false;


    public TMP_Text pointsLeftText;
    //public TMP_Text vidasLeftText;

    public GameObject gameOverUI;
    public GameObject prefabJugador;

    public GameObject recursos;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public GameObject bottomBorder;
    public GameObject topBorder;
    float minPosX, maxPosX, minPosY, maxPosY;

    Recurso rec;
    
  
    
    void Start()
    {
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
        vida3.SetActive(true);

        Time.timeScale = 1;
        float resourceSizeX = recursos.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float resourceSizeY = recursos.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        minPosX = leftBorder.transform.position.x + leftBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 + resourceSizeX / 2;
        maxPosX = rightBorder.transform.position.x - rightBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 - resourceSizeX / 2;
        minPosY = bottomBorder.transform.position.y + bottomBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 + resourceSizeY / 2;
        maxPosY = topBorder.transform.position.y - topBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 - resourceSizeY / 2;

        //food.SetActive(true);
        pointsLeftText.text = $"Puntos: {puntos}";
        //vidasLeftText.text = $"Vidas: {vidas}";
        SpawnJugador();
        Spawn();
    

    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        if (vidas == 2)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(false);
        }
        if (vidas == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }
        if (vidas == 0)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        GameOver();
        Recompensas();
        Niveles();
    }
    public void Spawn()
    {
        float posX = Random.Range(minPosX, maxPosX);
        float posY = Random.Range(minPosY, maxPosY);
        Vector2 randomPos = new Vector2(posX, posY);
        pos = Random.Range(0, 21);

        float veloc = UnityEngine.Random.Range(0, prob);
        if (veloc == 50)
        {
            
            if (pos <= 3)
            {
                pos = 0;
            }
            else if (pos >= 3 && pos <= 6)
            {
                pos = 1;
            }
            else if (pos >= 6 && pos <= 9)
            {
                pos = 2;
            }
            else if (pos >= 9 && pos <= 12)
            {
                pos = 3;
            }
            else if (pos >= 12 && pos <= 13)
            {
                pos = 4;
            }
            else if (pos >= 13 && pos <= 14)
            {
                pos = 5;
            }
            else if (pos >= 14 && pos <= 17)
            {
                pos = 6;
            }
            else if (pos >= 17 && pos <= 20)
            {
                pos = 7;
            }
            rec_vidas.Add(Instantiate(Recursos[pos], randomPos, Quaternion.identity, transform).GetComponent<Recursos>());
            

        }

    }
    
    public void GameOver()
    {
        if (vidas <= 0)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(true);

            if (UI1 == true)
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

    }
    public void Niveles()
    {
        if (puntos >= 100)
        {
            prob = 100;

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
            UI1 = false;
            UI2 = true;
            UI3 = false;
        }
        if (puntos >= 300)
        {
            prob = 50;

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
            UI1 = false;
            UI2 = false;
            UI3 = true;
        }
        if (puntos >= 5000)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
            botonPausa1.SetActive(false);
            botonPausa2.SetActive(false);
            botonPausa3.SetActive(false);

            menuPausa.SetActive(false);

            barran1.SetActive(false);
            barran2.SetActive(false);
            barran3.SetActive(false);


            TileMap1.SetActive(false);
            TileMap2.SetActive(false);
            TileMap3.SetActive(false);
            UI1 = false;
            UI2 = false;
            UI3 = true;
        }
    }
    private void SpawnJugador()
    {
        Instantiate(prefabJugador, new Vector3(0, -3.34f, 0), Quaternion.Euler(0, 0, 0));
    }
    public void Recompensas()
    {
        if(puntos == 20)
        {
            //2 de cada recurso
        }
        if (puntos == 40)
        {
            //3 de cada recurso
        }
        if (puntos == 100)
        {
            //Objeto para colocar en casa o 4 de cada recurso
        }
        if (puntos == 150)
        {
            //10 de cada recurso
        }
        if (puntos == 200)
        {
            //15 de cada recurso
        }
        if (puntos == 300)
        {
            //Objeto para colocar en la casa o 20 de cada recurso
        }
        if (puntos == 400)
        {
            //30 de cada recurso
        }
        if (puntos == 500)
        {
            //40 de cada recurso
        }
        if (puntos == 1000)
        {
            //Objeto para colocar en la casa o 100 de cada recurso
        }
        if (puntos == 5000)
        {
            //Objeto especial que se podra colocar dentro o fuera de la casa
        }
        if (contCF == 100)
        {
            //Figura dorada de personaje que podra colocar dentro o fuera de la casa
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
        SceneManager.LoadScene(2);
    }


}
