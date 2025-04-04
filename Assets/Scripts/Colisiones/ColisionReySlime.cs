using UnityEngine;

public class ColisionReySlime : MonoBehaviour
{
    public int vida = 3;
    private int golpesRecibidos = 0;
    [SerializeField] private GameObject gameOverUI;
    public GameObject imagenVictoria;
    public GameObject imagenGameOver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Proyectil"))
        {
            golpesRecibidos++;
            Debug.Log("El Rey Slime ha recibido un golpe. Total: " + golpesRecibidos);

            if (EfectosDeSonido.instance != null)
            {
                EfectosDeSonido.instance.EnemigoDestruido();
            }
            if (golpesRecibidos >= vida)
            {
                Debug.Log("¡Has derrotado al Rey Slime! ¡Victoria!");
                Victoria();
            }
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Jugador"))
        {
            Debug.Log("El enemigo tocó al jugador");
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();
            if (inventario != null)
            {
                if (EfectosDeSonido.instance != null)
                {
                    EfectosDeSonido.instance.JugadorRecibeDanio();
                }
                inventario.PerderVida(); // Resta una vida al jugador
            }
        }
    }

    private void Victoria()
    {
        Debug.Log("¡Victoria! Muestra pantalla de victoria o pasa al siguiente nivel.");
        if (EfectosDeSonido.instance != null)
        {
            EfectosDeSonido.instance.Win();
        }
        imagenVictoria.SetActive(true);
        imagenGameOver.SetActive(false);
        Time.timeScale = 0; // Pausar el juego
        if (gameOverUI != null) gameOverUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
