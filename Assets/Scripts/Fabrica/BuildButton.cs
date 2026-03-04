using Manager;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Botón de la UI que asigna un prefab al BuildManager.
/// </summary>
[RequireComponent(typeof(Button))]
public class BuildButton : MonoBehaviour
{
    [SerializeField] private GameObject structurePrefab;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (structurePrefab != null)
        {
            BuildManager.Instance.SelectStructure(structurePrefab);
            if (structurePrefab.transform.tag == "Generador")
            {
                GameManager.Instance.LowerTotalMadera(2);
            }
            if (structurePrefab.transform.tag == "Cinta")
            {
                GameManager.Instance.LowerTotalPiedra(2);
            }
            if (structurePrefab.transform.tag == "Deposito")
            {
                GameManager.Instance.LowerTotalHilo(2);
            }
            if (structurePrefab.transform.tag == "MesaProcesadoMadera")
            {
                GameManager.Instance.LowerTotalMadera(2);
            }
            if (structurePrefab.transform.tag == "MesaProcesadoPiedra")
            {
                GameManager.Instance.LowerTotalPiedra(2);
            }
            if (structurePrefab.transform.tag == "MesaProcesadoHilo")
            {
                GameManager.Instance.LowerTotalHilo(2);
            }
        }
        else
            Debug.LogWarning("⚠️ No hay prefab asignado al botón.");
    }
}
