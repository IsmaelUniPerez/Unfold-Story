using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void CargarEscena()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("No se ha asignado un nombre de escena en el inspector.");
        }
    }
    public void CargarMenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}