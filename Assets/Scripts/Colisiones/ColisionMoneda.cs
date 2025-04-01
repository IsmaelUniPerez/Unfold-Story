using UnityEngine;

public class MonedasExtra : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador")) // Verifica que solo colisione con el jugador
        {
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();

            if (inventario != null)
            {
                if (inventario.monedasJugador < 50)  // Asegura que no se sobrepasen las 50 monedas
                {
                    if (EfectosDeSonido.instance != null)
                    {
                        EfectosDeSonido.instance.Moneda();
                    }
                    inventario.monedasJugador++;
                    Debug.Log("Moneda extra obtenida. Monedas actuales: " + inventario.monedasJugador);
                    inventario.ActualizarUI(); // Usa el método público para actualizar la UI
                    Destroy(gameObject); // Destruye el objeto después de recogerlo
                }
                else
                {
                    Debug.Log("Monedas al máximo. Monedas actuales: " + inventario.monedasJugador);
                }
            }
        }
    }
}
