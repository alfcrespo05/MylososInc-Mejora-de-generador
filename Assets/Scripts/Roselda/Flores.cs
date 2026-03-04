using System.Collections;
using UnityEngine;

public class Flores : MonoBehaviour
{
    
    public float Puntos = 0;
    public float valor = 0;
    public float tiempo = 5;
    public int posF;
    public Flor florData;
  
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Timer());
        
    }

    //private void OnMouseDown()
    //{
    //    Destroy(gameObject);
      
    //}
    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(7);
        Debug.Log("Objeto destruido");
        Destroy(gameObject);
    }

   



}
