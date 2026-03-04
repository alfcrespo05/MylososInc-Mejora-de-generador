using UnityEngine;

public class SpawnBlockDetector : MonoBehaviour
{
    public string TagBloqueante = "Ecocombustible";
    public float tiempo;

    public float timer;
    public bool bloqueado;
    void Awake()
    {
        tiempo = 5;
        bloqueado = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(TagBloqueante))
        {
            timer += Time.deltaTime;

            if (timer >= tiempo && bloqueado == false)
            {
                bloqueado = true;
                Debug.Log("Spawn bloqueado por objeto durante demasiado tiempo");
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(TagBloqueante))
        {
            timer = 0;
            bloqueado = false;
            Debug.Log("Spawn desbloqueado");
        }
    }
}
