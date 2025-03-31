using UnityEngine;

public class TiendaColision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador")) // Verifica si el objeto que colisiona es el jugador
        {
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();
            if (inventario == null) return; // Si no hay un inventario, salir

            if (CompareTag("ComprarVida")) // Si este objeto es una tienda de vida
            {
                ComprarVida(inventario);
            }
            else if (CompareTag("ComprarMunicion")) // Si este objeto es una tienda de munición
            {
                ComprarMunicion(inventario);
            }
        }
    }

    private void ComprarVida(InventarioJugador inventario)
    {
        if (inventario.monedasJugador >= 2 && inventario.vidasJugador < 3)
        {
            inventario.monedasJugador -= 2; // Resta monedas
            inventario.vidasJugador += 1; // Agrega una vida
            inventario.ActualizarUI();
            Debug.Log("Vida comprada");
        }
        else
        {
            Debug.Log("No tienes suficientes monedas o ya tienes el máximo de vidas.");
        }
    }

    private void ComprarMunicion(InventarioJugador inventario)
    {
        if (inventario.monedasJugador >= 1 && inventario.municionJugador < 20)
        {
            inventario.monedasJugador -= 1; // Resta monedas
            inventario.municionJugador += 1; // Agrega una munición
            inventario.ActualizarUI();
            Debug.Log("Munición comprada");
        }
        else
        {
            Debug.Log("No tienes suficientes monedas o ya tienes el máximo de munición.");
        }
    }
}