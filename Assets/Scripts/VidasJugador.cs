using UnityEngine;

public class VidasJugador : MonoBehaviour
{
    public int vida = 3;

    public void PerderVida(int cantidad)
    {
        vida -= cantidad;
        Debug.Log("Vida del jugador: " + vida);
        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Debug.Log("El jugador ha muerto.");
        Destroy(gameObject);
    }
}
