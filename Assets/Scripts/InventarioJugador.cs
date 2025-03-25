using UnityEngine;

public class InventarioJugador : MonoBehaviour
{
    public int llavesJugador = 0;
    public int vidasJugador = 3;
    public int municionJugador = 0;
    public int monedasJugador = 0;

    public void AgregarLlaves()
    {
        llavesJugador += 1;
        Debug.Log("Llaves: " + llavesJugador);
    }

    public bool TieneSuficientesLlaves(int cantidadRequerida)
    {
        return llavesJugador >= cantidadRequerida;
    }
}
