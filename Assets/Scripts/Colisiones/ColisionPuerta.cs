using UnityEngine;

public class ColisionPuerta : MonoBehaviour
{
    public int llavesRequeridas = 1;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            // Obtiene el script del inventario del jugador
            InventarioJugador inventario = collision.gameObject.GetComponent<InventarioJugador>();

            if (inventario != null && inventario.TieneSuficientesLlaves(llavesRequeridas))
            {
                // Resta las llaves necesarias
                for (int i = 0; i < llavesRequeridas; i++)
                {
                    inventario.llavesJugador--; // Resta 1 llave por cada llave requerida
                }

                Debug.Log("¡Obstáculo superado! La puerta se abre.");
                Destroy(gameObject);  // Destruye la puerta
                inventario.ActualizarUI();  // Actualiza la UI para reflejar las llaves restantes
            }
            else
            {
                Debug.Log("No tienes suficientes llaves para pasar la puerta.");
            }
        }
    }
}