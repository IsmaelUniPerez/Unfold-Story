using UnityEngine;

public class MunicionExtra : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador")) // Verifica que solo colisione con el jugador
        {
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();

            if (inventario != null)
            {
                if (inventario.municionJugador < 20)  // Asegura que no se sobrepasen los 20 proyectiles
                {
                    inventario.municionJugador++;  // Suma solo 1 proyectil
                    Debug.Log("Munición extra obtenida. Munición actual: " + inventario.municionJugador);
                    inventario.ActualizarUI(); // Usa el método público para actualizar la UI
                    Destroy(gameObject); // Destruye el objeto después de recogerlo
                }
                else
                {
                    Debug.Log("Munición al máximo. Munición actual: " + inventario.municionJugador);
                }
            }
        }
    }
}
