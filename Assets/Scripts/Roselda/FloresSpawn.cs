
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FloresSpawn : MonoBehaviour
{
    public List<Flores> Flores;
    List<Flores> flor = new List<Flores>();
    public GameObject flores;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public GameObject bottomBorder;
    public GameObject topBorder;
    float minPosX, maxPosX, minPosY, maxPosY;

    [SerializeField] private int vidas = 4;
    [SerializeField] public int puntos = 0;

    int prob = 250;
    
    int contRosas = 0;

    private bool UI1 = true;
    private bool UI2 = false;
    private bool UI3 = false;

    public TMP_Text pointsLeftText;
    public TMP_Text vidasLeftText;

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
    [SerializeField] private GameObject vida4;

    public GameObject gameOverUI;

   



    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        vida4.SetActive(true);
        gameOverUI.SetActive(false);
        Time.timeScale = 1;

        float foodSizeX = flores.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float foodSizeY = flores.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        minPosX = leftBorder.transform.position.x + leftBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 + foodSizeX / 2;
        maxPosX = rightBorder.transform.position.x - rightBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 - foodSizeX / 2;
        minPosY = bottomBorder.transform.position.y + bottomBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 + foodSizeY / 2;
        maxPosY = topBorder.transform.position.y - topBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 - foodSizeY / 2;

        puntos = 0;
        pointsLeftText.text = $"Puntos: {puntos}";

    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        CheckMouseClickDown();

    }
    private void FixedUpdate()
    {
        VidasCheck();
    }
    public void Spawn()
    {
        float posX = Random.Range(minPosX, maxPosX);
        float posY = Random.Range(minPosY, maxPosY);
        Vector2 randomPos = new Vector2(posX, posY);
        float veloc = UnityEngine.Random.Range(0, prob);
        
        if(veloc == 100)
        {
            
            int pos = UnityEngine.Random.Range(0,21);
            if(pos <= 3)
            {
                pos = 0;
            }
            else if(pos >= 3 && pos <= 6)
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
           
            Instantiate(Flores[pos], randomPos, Quaternion.identity, transform);
           

        }
        

       
    }
    private void CheckMouseClickDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 1);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 10.1f);

            if (hit)
            {
                if (hit.collider.CompareTag("FlorRosa"))
                {
                    Debug.Log("HIT-FR");
                    Destroy(hit.collider.gameObject);
                    puntos += 1;
                    pointsLeftText.text = $"Puntos: {puntos}";

                }

                else if (hit.collider.CompareTag("FlorMorada"))
                {
                    Debug.Log("HIT-FM");
                    Destroy(hit.collider.gameObject);
                    puntos += 1;
                    pointsLeftText.text = $"Puntos: {puntos}";

                }

                else if (hit.collider.CompareTag("FlorAzul"))
                {
                    Debug.Log("HIT-FA");
                    Destroy(hit.collider.gameObject);
                    puntos += 1;
                    pointsLeftText.text = $"Puntos: {puntos}";

                }

                else if (hit.collider.CompareTag("Valeriana"))
                {
                    Debug.Log("HIT-V");
                    Destroy(hit.collider.gameObject);
                    puntos += 2;
                    pointsLeftText.text = $"Puntos: {puntos}";

                }

                else if (hit.collider.CompareTag("Rosa"))
                {
                    Debug.Log("HIT-R");
                    Destroy(hit.collider.gameObject);
                    puntos += 5;
                    pointsLeftText.text = $"Puntos: {puntos}";
                }

                else if (hit.collider.CompareTag("FlorNegra"))
                {
                    Debug.Log("HIT-FN");
                    Destroy(hit.collider.gameObject);
                    puntos = puntos / 2;
                    if (puntos <= 0)
                    {
                        puntos = 0;
                    }
                    pointsLeftText.text = $"Puntos: {puntos}";
                    vidas -= 1;
                    vidasLeftText.text = $"Vidas: {vidas}";

                }

                else if (hit.collider.CompareTag("Cactus"))
                {
                    Debug.Log("HIT-C");
                    Destroy(hit.collider.gameObject);
                    puntos -= 1;
                    if (puntos <= 0)
                    {
                        puntos = 0;
                    }
                    pointsLeftText.text = $"Puntos: {puntos}";
                    vidas -= 1;
                    vidasLeftText.text = $"Vidas: {vidas}";

                }

                else if (hit.collider.CompareTag("PlantaConEspinas"))
                {
                    Debug.Log("HIT-PE");
                    Destroy(hit.collider.gameObject);
                    puntos -= 5;
                    if (puntos <= 0)
                    {
                        puntos = 0;
                    }
                    pointsLeftText.text = $"Puntos: {puntos}";
                    vidas -= 1;
                    vidasLeftText.text = $"Vidas: {vidas}";
                }
            }
        }
    }

    public void VidasCheck()
    {
      
        if (vidas == 3)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
            vida4.SetActive(false);
            
        }
        if (vidas == 2)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(false);
            vida4.SetActive(false);
            
        }
        if (vidas == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
            vida3.SetActive(false);
            vida4.SetActive(false);
           
        }
        if (vidas == 0)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
            vida4.SetActive(false);
            GameOver();
        }
    }
    public void GameOver()
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
    //public void Espinas()
    //{
    //    bool esp = flor[pos].florData.Espinas;
    //    if (esp == false)
    //    {
    //        FloresSpawn controller = GameObject.FindGameObjectWithTag("GCR").GetComponent<FloresSpawn>();
    //        controller.RestarVidas();
    //        controller.AñadirPuntos();
    //    }

    //}
    //public void AñadirPuntos()
    //{
    //    //puntos += 100;
    //    //pointsLeftText.text = $"Puntos: {puntos}";
    //    int punto = flor[pos].florData.puntos;
    //    puntos += punto;
    //    pointsLeftText.text = $"Puntos: {puntos}";
    //}
    public void Niveles()
    {
        if (puntos >= 100)
        {
            prob = 150;

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
        if (puntos >= 250)
        {
            prob = 100;

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
    public void Recompensas()
    {
        if (puntos == 20)
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
        if (contRosas == 100)
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
        SceneManager.LoadScene(5);
    }
}
