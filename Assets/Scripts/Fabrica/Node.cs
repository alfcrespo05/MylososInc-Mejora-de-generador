
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node cameFrom;
    public List<Node> connections;
    [SerializeField] private Color _baseColor, _offsetColor, _occupiedColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool node = true;


    public bool IsOccupied;
    public GameObject Occupant;

    private Color _originalColor;

    public float gScore;
    public float hScore;

    void Update()
    {
        CheckNode();
        
    }
    public float FScore()
    {
        return gScore + hScore;
    }

    private void OnDrawGizmos()
    {
        if (this == null) return;
        if (connections.Count > 0)
        {
            Gizmos.color = Color.blue;
            for (int i = 0; i < connections.Count; i++)
            {
                Gizmos.DrawLine(transform.position, connections[i].transform.position);
            }
        }
    }
    public void Init(bool isOffset)
    {
        _originalColor = isOffset ? _offsetColor : _baseColor;
        _renderer.color = _originalColor;
        IsOccupied = false;

        Occupant = null;
    }

    public void SetOccupied(GameObject occupant)
    {
        IsOccupied = true;
        Occupant = occupant;
        _renderer.color = _occupiedColor;
    }

    public void ClearOccupation()
    {
        IsOccupied = false;
        Occupant = null;
        _renderer.color = _originalColor;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Generador"))
        {
            node = false;
        }
        if (collision.CompareTag("Deposito"))
        {
            node = false;
        }
        if (collision.CompareTag("Cinta"))
        {
            node = false;
        }
        if (collision.CompareTag("MesaProcesadoHilo"))
        {
            node = false;
        }
        if (collision.CompareTag("MesaProcesadoMadera"))
        {
            node = false;
        }
        if (collision.CompareTag("MesaProcesadoPiedra"))
        {
            node = false;
        }
    }
     
         

    
    private void CheckNode()
    {
        if (node == false)
        {
            gameObject.SetActive(false);
        }
        else gameObject.SetActive(true);

    }
}




