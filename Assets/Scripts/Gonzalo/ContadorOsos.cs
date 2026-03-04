using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ContadorOsos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OM")
        {
            Debug.Log("Tendria que haber sido gameover con el screencollider");
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            controller.GameOver();
            
        }
        if (collision.gameObject.tag == "OM2")
        {
            
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            controller.GameOver();

        }
        if (collision.gameObject.tag == "OM3")
        {
            
            GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            controller.GameOver();

        }
    }

}
