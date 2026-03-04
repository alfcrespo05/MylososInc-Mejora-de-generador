using UnityEngine;
using System.Collections.Generic;

public class EstructuraEditable : MonoBehaviour
{
    public int sizeX = 1;
    public int sizeY = 1;

    private bool isDragging = false;
    //private bool isPlaced = false;
    private Tile currentTile;
    private Vector2 offset;
    private Vector2 lastCenterGridPos;
    private Camera mainCam;
    private GridManager gridManager;
    private List<Tile> occupiedTiles = new List<Tile>();

    void Start()
    {
        mainCam = Camera.main;
        gridManager = FindFirstObjectByType<GridManager>();

        AutoSnapToGrid();
    }

    public void AutoSnapToGrid()
    {
        if (gridManager == null)
        {
            Debug.LogError("GridManager no encontrado en la escena");
            return;
        }

        Vector2 centerGridPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        if (!CanOccupy(centerGridPos))
        {
            Debug.LogWarning("no pudo colocarse automáticamente (espacio ocupado o fuera del grid).");
            return;
        }

        transform.position = GetCenteredPosition(centerGridPos);
        MarkTiles(centerGridPos, true);
        lastCenterGridPos = centerGridPos;
    }

    private bool CanOccupy(Vector2 center)
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                Vector2 tilePos = new Vector2(center.x + x - (sizeX / 2), center.y + y - (sizeY / 2));
                Tile tile = gridManager.GetTileAtPosition(tilePos);

                if (tile == null || (tile.IsOccupied && !occupiedTiles.Contains(tile)))
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void MarkTiles(Vector2 center, bool occupied)
    {
        ClearOccupiedTiles();

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                Vector2 tilePos = new Vector2(center.x + x - (sizeX / 2), center.y + y - (sizeY / 2));
                Tile tile = gridManager.GetTileAtPosition(tilePos);

                if (tile != null)
                {
                    if (occupied)
                        tile.SetOccupied(gameObject);

                    occupiedTiles.Add(tile);
                }
            }
        }
    }

    private void ClearOccupiedTiles()
    {
        foreach (var tile in occupiedTiles)
        {
            if (tile != null)
                tile.ClearOccupation();
        }
        occupiedTiles.Clear();
    }

    private Vector3 GetCenteredPosition(Vector2 gridCenter)
    {
        float offsetX = (sizeX % 2 == 0) ? -0.5f : 0f;
        float offsetY = (sizeY % 2 == 0) ? -0.5f : 0f;

        return new Vector3(gridCenter.x + offsetX, gridCenter.y + offsetY, 0f);
    }

    private void OnMouseDown()
    {
        isDragging = true;

        // Liberar tiles actuales
        ClearOccupiedTiles();

        Vector3 mouseWorld = mainCam.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorld.x, mouseWorld.y, transform.position.z);
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 mouseWorld = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector2(mouseWorld.x, mouseWorld.y) + offset;

        Vector2 centerGridPos = new Vector2(Mathf.Round(newPos.x), Mathf.Round(newPos.y));
        transform.position = GetCenteredPosition(centerGridPos);
    }

    private void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;

        Vector2 centerGridPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        // Comprobar si puede ocupar los nuevos tiles
        if (CanOccupy(centerGridPos))
        {
            //Puede colocarse aquí
            transform.position = GetCenteredPosition(centerGridPos);
            MarkTiles(centerGridPos, true);
            lastCenterGridPos = centerGridPos;
            Debug.Log($" {name} colocada en {centerGridPos}");
        }
        else
        {
            //No puede colocarse: volver a la posición anterior y recolocar
            Debug.Log(" Espacio ocupado, devolviendo a posición anterior.");
            transform.position = GetCenteredPosition(lastCenterGridPos);
            MarkTiles(lastCenterGridPos, true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, Vector2.one*0.9f);
    }
}
