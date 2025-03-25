using UnityEngine;

public class ColisionLlave : MonoBehaviour
{
    private bool recogida = false;
    void OnTriggerEnter(Collider other)
    {
        if (recogida) return; // Si ya se recogió, no hacer nada

        if (other.CompareTag("Jugador"))
        {
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();
            if (inventario != null)
            {
                recogida = true; // Marca la llave como recogida
                inventario.AgregarLlaves();
                Debug.Log("Llave recogida");
                Destroy(gameObject);
            }
        }
    }
}
