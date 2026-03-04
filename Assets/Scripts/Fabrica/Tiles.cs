using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor, _occupiedColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
   


    public bool IsOccupied;
    public GameObject Occupant;

    private Color _originalColor;

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
        _renderer.color= _originalColor;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}

