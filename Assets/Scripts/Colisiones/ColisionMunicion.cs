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
                    Debug.Log("Munici�n extra obtenida. Munici�n actual: " + inventario.municionJugador);
                    inventario.ActualizarUI(); // Usa el m�todo p�blico para actualizar la UI
                    Destroy(gameObject); // Destruye el objeto despu�s de recogerlo
                }
                else
                {
                    Debug.Log("Munici�n al m�ximo. Munici�n actual: " + inventario.municionJugador);
                }
            }
        }
    }
}
