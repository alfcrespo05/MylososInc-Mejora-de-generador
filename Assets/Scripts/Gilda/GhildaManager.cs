using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GhildaManager : MonoBehaviour
{
    public List<Gildas> Gildas;
    List<Gildas> gil_vidas = new List<Gildas>();
    Movimiento mov;
    Gildas gilda;
  
    public GameObject prefabGhilda;
    public GameObject prefabGildas;

    public TMP_Text puntosText;
    [SerializeField] public int puntos = 0;

    [SerializeField] public int pos;
    int prob = 150;
    int contGPQ = 0;

    private bool UI1 = true;
    private bool UI2 = false;
    private bool UI3 = false;

    public GameObject food;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public GameObject bottomBorder;
    public GameObject topBorder;
    float minPosX, maxPosX, minPosY, maxPosY;

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

    private bool buffDoblePuntos = false;
    private int objetosRestantesBuff = 0;

    [SerializeField] private TMP_Text buffText;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntosText.text = $"Puntos: {puntos}";
        mov = Instantiate(prefabGhilda, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Movimiento>();
        
        float foodSizeX = food.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float foodSizeY = food.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

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

        gameOverUI.SetActive(false);

        minPosX = leftBorder.transform.position.x + leftBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 + foodSizeX / 2;
        maxPosX = rightBorder.transform.position.x - rightBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 - foodSizeX / 2;
        minPosY = bottomBorder.transform.position.y + bottomBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 + foodSizeY / 2;
        maxPosY = topBorder.transform.position.y - topBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 - foodSizeY / 2;

      
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    private void FixedUpdate()
    {
        //GameOverC();
        Niveles();
        Recompensas();
    }
    //public void SumarPunto()
    //{
    
    //    int punto = gil_vidas[gilda.posG].gildaData.puntos;
    //    puntos += punto;
    //    puntosText.text = $"Puntos: {puntos}";
    //}
    public void Comido()
    {
        Invoke("Spawn", 1f);
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

            if (pos <= 4)
            {
                pos = 0;
            }
            if (pos >= 4 && pos <= 8)
            {
                pos = 1;
            }
            if (pos >= 8 && pos <= 10)
            {
                pos = 2;
            }
            if (pos >= 10 && pos <= 12)
            {
                pos = 3;
            }
            if (pos >= 12 && pos <= 16)
            {
                pos = 4;
            }
            if (pos >= 16 && pos <= 20)
            {
                pos = 5;
            }
            
            
           Instantiate(Gildas[pos], randomPos, Quaternion.identity, transform).GetComponent<Gildas>();
            
           
        }
       
    }

    //public void Herramienta()
    //{
    //    bool her = gil_vidas[gilda.posG].gildaData.Herramienta;
    //    if (her == false)
    //    {
    //        GhildaManager controller = GameObject.FindGameObjectWithTag("GhildaManager").GetComponent<GhildaManager>();
    //        controller.SumarPunto();
    //    }

    //}
    public void SumarPuntos(int cantidad)
    {
        if (buffDoblePuntos && objetosRestantesBuff > 0)
        {
            cantidad *= 2;
            objetosRestantesBuff--;

            if (objetosRestantesBuff <= 0)
            {
                buffDoblePuntos = false;
            }

            ActualizarUIBuff();
        }

        puntos += cantidad;

        if (puntos < 0)
            puntos = 0;

        puntosText.text = $"Puntos: {puntos}";
    }
    public void ActivarBuffGB()
    {
        buffDoblePuntos = true;
        objetosRestantesBuff = 6; // próximos 5 objetos
        Debug.Log("Buff activado para 5 objetos");
        ActualizarUIBuff();
    }
    private void ActualizarUIBuff()
    {
        if (buffDoblePuntos)
        {
            buffText.text = $"x2 ({objetosRestantesBuff})";
            buffText.gameObject.SetActive(true);
            buffText.color = new Color(1f, 0.75f, 0f);
        }
        else
        {
            buffText.text = "";
            buffText.gameObject.SetActive(false);
        }
    }


    public IEnumerator IfIsGPQ()
    {
        mov.CancelInvoke("movimiento");           // Detiene el InvokeRepeating actual
        mov.frecuencia = mov.frecuencia * 2;     // Cambia la frecuencia
        mov.InvokeRepeating("movimiento", 0f, mov.frecuencia); // Reinicia con nueva frecuencia
        Debug.Log("Frecuencia" + mov.frecuencia);
        yield return new WaitForSeconds(5);      // Espera el tiempo de efecto
        mov.CancelInvoke("movimiento");          // Detén el InvokeRepeating
        mov.frecuencia = mov.frecuencia / 2;    // Restaura la frecuencia original
        mov.InvokeRepeating("movimiento", 0f, mov.frecuencia); // Vuelve a arrancar
        Debug.Log("Frecuencia" + mov.frecuencia);
    }
    public IEnumerator IfIsDestornillador()
    {
        mov.CancelInvoke("movimiento");           // Detiene el InvokeRepeating actual
        mov.frecuencia = mov.frecuencia / 2;     // Cambia la frecuencia
        mov.InvokeRepeating("movimiento", 0f, mov.frecuencia); // Reinicia con nueva frecuencia
        Debug.Log("Frecuencia" + mov.frecuencia);
        yield return new WaitForSeconds(10);      // Espera el tiempo de efecto
        mov.CancelInvoke("movimiento");          // Detén el InvokeRepeating
        mov.frecuencia = mov.frecuencia * 2;    // Restaura la frecuencia original
        mov.InvokeRepeating("movimiento", 0f, mov.frecuencia); // Vuelve a arrancar
        Debug.Log("Frecuencia" + mov.frecuencia);
    }
    public void IfIsMartillo()
    {
        float posX = Random.Range(minPosX, maxPosX);
        float posY = Random.Range(minPosY, maxPosY);

        Vector2 randomPos = new Vector2(posX, posY);

        GameObject jugador = GameObject.FindGameObjectWithTag("Ghilda");
        jugador.transform.position = randomPos;
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
    public void Niveles()
    {
        if (puntos >= 100)
        {
            mov.frecuencia = 0.15f;
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
            mov.frecuencia = 0.05f;
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
        if (contGPQ == 100)
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
        SceneManager.LoadScene(3);
    }

}
