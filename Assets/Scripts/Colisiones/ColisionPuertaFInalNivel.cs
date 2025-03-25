using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionPuertaFInalNivel : MonoBehaviour
{
    [SerializeField] private string[] ordenEscenas; // Lista de escenas en orden
    private int escenaActual = 0; // Índice de la escena actual

    private void Start()
    {
        // Busca el índice de la escena actual en la lista
        string currentScene = SceneManager.GetActiveScene().name;
        for (int i = 0; i < ordenEscenas.Length; i++)
        {
            if (ordenEscenas[i] == currentScene)
            {
                escenaActual = i;
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            CargarSiguienteEscena();
        }
    }

    private void CargarSiguienteEscena()
    {
        if (ordenEscenas.Length == 0) return; // Evita errores si no hay escenas configuradas

        // Avanzar al siguiente nivel
        int nextSceneIndex = (escenaActual + 1) % ordenEscenas.Length;
        string nextScene = ordenEscenas[nextSceneIndex];

        SceneManager.LoadScene(nextScene);
    }
}
