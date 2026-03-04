using UnityEngine;
using UnityEngine.UIElements;

public class OM_Movimiento : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool IsMovingRight = true;
    public float baseSpeed = 0.4f;
   
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
      Movimiento();
        
    }
    private void Movimiento()
    {
        float movi = baseSpeed * Time.deltaTime;
        transform.Translate(IsMovingRight ? movi : -movi, 0, 0);
    }
    private void ChangeDirection()
    {
        IsMovingRight = !IsMovingRight;
        baseSpeed += 0.3f;
        if(baseSpeed >= 2f)
        {
            baseSpeed = 2f;
        }
        transform.Translate(0, -0.4f, 0);

    }
    private bool IsBorder(Collider2D collision) => collision.gameObject.tag == "SCGO";
    //private bool IsJugador(Collider2D collision) => collision.gameObject.tag == "Gonzalo";
    
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsBorder(collision))
        {
            ChangeDirection();
        }
        //if (IsJugador(collision))
        //{
        //    GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //    controller.GameOver();
        //}
       
    }
  



}
