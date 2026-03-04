using UnityEngine;
using Manager;

public class GameManager : MonoBehaviour
{
    public int totalMadera;
    public int totalPiedra;
    public int totalHilo;
    public int totalDinero;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {

        UIManager1.Instance.SetTotalMadera(totalMadera);
        UIManager1.Instance.SetTotalPiedra(totalPiedra);
        UIManager1.Instance.SetTotalHilo(totalHilo);
        UIManager1.Instance.SetTotalDinero(totalDinero);
    }

    public void RaiseTotalMadera(int s)
    {
        totalMadera += s;
    }

    public void RaiseTotalPiedra(int s)
    {
        totalPiedra += s;
    }

    public void RaiseTotalHilo(int s)
    {
        totalHilo += s;
    }

    public void RaiseTotalDinero(int s)
    {
        totalDinero += s;
    }

    public void LowerTotalMadera(int s)
    {
        totalMadera -= s;
    }

    public void LowerTotalPiedra(int s)
    {
        totalPiedra -= s;
    }

    public void LowerTotalHilo(int s)
    {
        totalHilo -= s;
    }

    public void LowerTotalDinero(int s)
    {
        totalDinero -= s;
    }
  
}
