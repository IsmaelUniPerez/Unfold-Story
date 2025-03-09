using UnityEngine;

public class InventarioJugador : MonoBehaviour
{
    public int llavesJugador = 0;

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
