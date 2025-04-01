using System.Collections;
using UnityEngine;
using TMPro;

public class InventarioJugador : MonoBehaviour
{
    public int llavesJugador = 0;
    public int vidasJugador = 3;
    public int municionJugador = 0;
    public int monedasJugador = 0;

    [SerializeField] private TextMeshProUGUI llavesText;
    [SerializeField] private TextMeshProUGUI vidasText;
    [SerializeField] private TextMeshProUGUI municionText;
    [SerializeField] private TextMeshProUGUI monedasText;

    private SceneManagerController sceneManager;

    [SerializeField] private GameObject gameOverUI;
    private bool puedePerderVida = true;  // Variable para verificar si el jugador puede perder vida
    public float tiempoCooldownPerderVida = 3f;
    private void Start()
    {
        ActualizarUI();
        if (gameOverUI != null) gameOverUI.SetActive(false);
        sceneManager = FindFirstObjectByType<SceneManagerController>();
    }

    public void AgregarLlaves()
    {
        llavesJugador += 1;
        Debug.Log("llaves:" + llavesJugador);
        ActualizarUI();
    }

    public void AgregarMonedas(int cantidad)
    {
        monedasJugador += cantidad;
        Debug.Log("monedas:" + monedasJugador);
        ActualizarUI();
    }

    public void UsarMunicion(int cantidad)
    {
        if (municionJugador >= cantidad)
        {
            municionJugador -= cantidad;
            Debug.Log("municion:" + municionJugador);
            ActualizarUI();
        }
        else
        {
            Debug.Log("No tienes suficiente munición.");
        }
    }

    public void PerderVida()
    {
        if (vidasJugador > 1 && puedePerderVida)
        {
            vidasJugador--;
            Debug.Log("vidas:" + vidasJugador);
            ActualizarUI();
            StartCoroutine(CooldownPerderVida());
        }
        else if (vidasJugador == 1)
        {
            GameOver();
        }
    }

    // Corutina que maneja el cooldown
    private IEnumerator CooldownPerderVida()
    {
        puedePerderVida = false;  // Desactiva la posibilidad de perder vida temporalmente
        yield return new WaitForSeconds(tiempoCooldownPerderVida);  // Espera 3 segundos (ajusta este valor al cooldown deseado)
        puedePerderVida = true;  // Vuelve a habilitar la posibilidad de perder vida
    }

    public bool TieneSuficientesLlaves(int cantidadRequerida)
    {
        return llavesJugador >= cantidadRequerida;
    }

    public void ActualizarUI()
    {
        if (llavesText) llavesText.text = llavesJugador.ToString();
        if (vidasText) vidasText.text = vidasJugador.ToString();
        if (municionText) municionText.text = municionJugador.ToString();
        if (monedasText) monedasText.text = monedasJugador.ToString();
    }
    private void GameOver()
    {
        Debug.Log("¡Game Over!");
        Time.timeScale = 0; // Pausar el juego
        if (gameOverUI != null) gameOverUI.SetActive(true);
    }

    public void RegresarAlMenu()
    {
        Time.timeScale = 1; // Restaurar el tiempo antes de salir

        if (sceneManager != null)
        {
            sceneManager.CargarMenuPrincipal();
        }
        else
        {
            Debug.LogError("No se encontró SceneManagerController en la escena.");
        }
    }
}
