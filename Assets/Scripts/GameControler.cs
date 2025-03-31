using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isPaused = false; // Variable para saber si el juego está en pausa

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0; // Pausa el juego
        }
        else
        {
            Time.timeScale = 1; // Reanuda el juego
        }
    }
}
