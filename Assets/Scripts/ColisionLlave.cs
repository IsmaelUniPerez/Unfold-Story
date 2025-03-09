using UnityEngine;

public class ColisionLlave : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();
            if (inventario != null)
            {
                inventario.AgregarLlaves();
                Debug.Log("Llave recogida");
                Destroy(gameObject);
            }
        }
    }
}
