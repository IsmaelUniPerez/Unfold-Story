using UnityEngine;

public class ColisionPuerta : MonoBehaviour
{
    public int llavesRequeridas = 5;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            // Obtiene el script del inventario del jugador
            InventarioJugador inventario = collision.gameObject.GetComponent<InventarioJugador>();

            if (inventario != null && inventario.TieneSuficientesLlaves(llavesRequeridas))
            {
                Debug.Log("¡Obstáculo superado! La puerta se abre.");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("No tienes suficientes llaves para pasar la puerta.");
            }
        }
    }
}
