using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerMP : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotonSalir()
    {
        Application.Quit();
    
    }
    public void BotonAjustes()
    {

    }
    public void BotonEmpezar()
    {
        SceneManager.LoadScene(1);
    }
}
