using UnityEngine;

public class ColisionEnemigo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Proyectil"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Jugador"))
        {
            Debug.Log("El enemigo tocó al jugador");
            VidasJugador jugador = other.GetComponent<VidasJugador>();
            if (jugador != null)
            {
                jugador.PerderVida(1);
            }
        }
    }
}
