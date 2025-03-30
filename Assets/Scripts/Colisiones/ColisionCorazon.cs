using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador")) // Verifica que solo colisione con el jugador
        {
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();

            if (inventario != null)
            {
                if (inventario.vidasJugador < 3) // Verifica que no supere el máximo
                {
                    inventario.vidasJugador++;
                    Debug.Log("Vida extra obtenida. Vidas actuales: " + inventario.vidasJugador);
                    inventario.ActualizarUI(); // Usa el método público para actualizar la UI
                    Destroy(gameObject); // Destruye el objeto después de recogerlo
                }
                else
                {
                    Debug.Log("No puedes tener más de 3 vidas.");
                }
            }
        }
    }
}

