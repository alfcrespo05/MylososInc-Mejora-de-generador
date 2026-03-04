using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Gestiona la colocación de estructuras seleccionadas desde la UI.
/// </summary>
public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance; // Singleton simple para acceso global

    [Header("Cámara principal")]
    [SerializeField] private Camera mainCam;

    private GameObject currentGhost;     // Instancia temporal (siguiendo el mouse)
    private GameObject selectedPrefab;   // Prefab de estructura seleccionada
   
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (currentGhost == null) return;

        // Evitar construir sobre UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

        // Seguir el mouse con snapping al grid
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 snappedPos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
        currentGhost.transform.position = snappedPos;

        // Click izquierdo = colocar
        if (Input.GetMouseButtonDown(0))
        {
            PlaceStructure();
        }

        // Click derecho = cancelar
        if (Input.GetMouseButtonDown(1))
        {
            CancelPlacement();
        }
    }

    /// <summary>
    /// Llamado desde los botones de la UI para seleccionar un tipo de estructura.
    /// </summary>
    public void SelectStructure(GameObject prefab)
    {
        CancelPlacement();

        selectedPrefab = prefab;
        currentGhost = Instantiate(prefab);
        currentGhost.name = prefab.name + "_Ghost";

        // Desactivar cualquier comportamiento no necesario mientras está en modo “fantasma”
        var placeable = currentGhost.GetComponent<EstructuraEditable>();
        if (placeable != null)
            placeable.enabled = false; // Lo activamos al colocar

        // Hacerla transparente (preview visual)
        SetGhostTransparency(currentGhost, 0.5f);
    }

    /// <summary>
    /// Coloca la estructura en la escena definitivamente.
    /// </summary>
    private void PlaceStructure()
    {
        if (selectedPrefab == null) return;

        // Instanciamos la estructura real en esa posición
        GameObject placed = Instantiate(selectedPrefab, currentGhost.transform.position, Quaternion.identity);
        placed.name = selectedPrefab.name;

        // Activamos el comportamiento de colocación
        var placeable = placed.GetComponent<EstructuraEditable>();
        if (placeable != null)
        {
            placeable.enabled = true;
            placeable.AutoSnapToGrid(); // 🟢 colocamos automáticamente
        }

        CancelPlacement(); // Salimos del modo construcción (puedes quitar esto si quieres seguir construyendo)
    }

    /// <summary>
    /// Cancela la construcción actual (click derecho).
    /// </summary>
    private void CancelPlacement()
    {
        if (currentGhost != null)
            Destroy(currentGhost);
        currentGhost = null;
        selectedPrefab = null;
    }

    /// <summary>
    /// Hace a un objeto y sus hijos semitransparentes.
    /// </summary>
    private void SetGhostTransparency(GameObject obj, float alpha)
    {
        foreach (var renderer in obj.GetComponentsInChildren<SpriteRenderer>())
        {
            Color c = renderer.color;
            c.a = alpha;
            renderer.color = c;
        }
    }
}
