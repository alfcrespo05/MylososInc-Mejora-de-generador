using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Manager
{
    public class UIManager1 : MonoBehaviour
    {
        public TextMeshProUGUI TotalMadera;
        public TextMeshProUGUI TotalPiedra;
        public TextMeshProUGUI TotalHilo;
        public TextMeshProUGUI TotalDinero;
        public static UIManager1 Instance;
        [SerializeField] private GameObject botonPausa;
        [SerializeField] private GameObject menuPausa;
    
       
        public GameObject panelMejora;
        public GameObject panelMejora1;
        public GameObject panelMejora2;
        void Start()
        {
            botonPausa.SetActive(true);
            menuPausa.SetActive(false);
           
            
            panelMejora.SetActive(false);
            panelMejora1.SetActive(false);
            panelMejora2.SetActive(false);
        }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void SetTotalMadera(double value)
        {
            string labelValue = FormatNumbers.Format(value);
            TotalMadera.text = labelValue;
        }
        public void SetTotalPiedra(double value)
        {
            string labelValue = FormatNumbers.Format(value);
            TotalPiedra.text = labelValue;
        }
        public void SetTotalHilo(double value)
        {
            string labelValue = FormatNumbers.Format(value);
            TotalHilo.text = labelValue;
        }
        public void SetTotalDinero(double value)
        {
            string labelValue = FormatNumbers.Format(value);
            TotalDinero.text = labelValue;
        }
        public void BotonPausa()
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0;
            else Time.timeScale = 1;
            botonPausa.SetActive(false);
            menuPausa.SetActive(true);
           
          
        }
        public void Reanudar()
        {
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            else Time.timeScale = 0;
            botonPausa.SetActive(true);
            menuPausa.SetActive(false);
           
         
        }
        public void Reanudar2()
        {
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            else Time.timeScale = 0;
            botonPausa.SetActive(true);
          
        
        }
        public void BotonMejoras()
        {
            botonPausa.SetActive(true);
            menuPausa.SetActive(false);
           
       
        }
        public void MostrarPanel(Vector3 posicion)
        {
            panelMejora.transform.position = posicion;
            panelMejora.SetActive(true);
            panelMejora1.SetActive(false);
            panelMejora2.SetActive(false);
        }
        public void MostrarPanel1(Vector3 posicion)
        {
            panelMejora1.transform.position = posicion;
            panelMejora.SetActive(false);
            panelMejora1.SetActive(true);
            panelMejora2.SetActive(false);
        }
        public void MostrarPanel2(Vector3 posicion)
        {
            panelMejora2.transform.position = posicion;
            panelMejora.SetActive(false);
            panelMejora1.SetActive(false);
            panelMejora2.SetActive(true);
        }

        public void OcultarPanel()
        {
            panelMejora.SetActive(false);
            panelMejora1.SetActive(false);
            panelMejora2.SetActive(false);
        }

    }
}


