using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerExterior : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject Resume;
    [SerializeField] private GameObject Salir;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject botonFederico;
    [SerializeField] private GameObject botonRoselda;
    [SerializeField] private GameObject botonGonzalo;
    [SerializeField] private GameObject botonGhilda;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);

        botonFederico.SetActive(true);
        botonRoselda.SetActive(true);
        botonGonzalo.SetActive(true);
        botonGhilda.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reanudar()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else Time.timeScale = 0;
        botonPausa.SetActive(true);

        menuPausa.SetActive(false);

        botonFederico.SetActive(true);
        botonRoselda.SetActive(true);
        botonGonzalo.SetActive(true);
        botonGhilda.SetActive(true);

    }
    public void BotonPausa()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else Time.timeScale = 1;
        botonPausa.SetActive(false);

        menuPausa.SetActive(true);

        Resume.SetActive(true);
        Salir.SetActive(true);

        botonFederico.SetActive(false);
        botonRoselda.SetActive(false);
        botonGonzalo.SetActive(false);
        botonGhilda.SetActive(false);

    }
    public void BotonSalir()
    {
        Application.Quit();
      
    }
    public void BotonAjustes()
    {

    }
    public void BotonFederico()
    {
        SceneManager.LoadScene(2);
    }
    public void BotonRoselda()
    {
        SceneManager.LoadScene(5);
    }
    public void BotonGonzalo()
    {
        SceneManager.LoadScene(4);
    }
    public void BotonGhilda()
    {
        SceneManager.LoadScene(3);
    }
}
