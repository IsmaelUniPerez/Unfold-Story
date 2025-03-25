using System.Collections;
using UnityEngine;
using TMPro;

public class InventarioJugador : MonoBehaviour
{
    public int llavesJugador = 0;
    public int vidasJugador = 3;
    public int municionJugador = 0;
    public int monedasJugador = 0;

    [SerializeField] private TextMeshProUGUI llavesText;
    [SerializeField] private TextMeshProUGUI vidasText;
    [SerializeField] private TextMeshProUGUI municionText;
    [SerializeField] private TextMeshProUGUI monedasText;

    private void Start()
    {
        ActualizarUI();
    }

    public void AgregarLlaves()
    {
        llavesJugador += 1;
        Debug.Log("llaves:" + llavesJugador);
        ActualizarUI();
    }

    public void AgregarMonedas(int cantidad)
    {
        monedasJugador += cantidad;
        Debug.Log("monedas:" + monedasJugador);
        ActualizarUI();
    }

    public void UsarMunicion(int cantidad)
    {
        if (municionJugador >= cantidad)
        {
            municionJugador -= cantidad;
            Debug.Log("municion:" + municionJugador);
            ActualizarUI();
        }
        else
        {
            Debug.Log("No tienes suficiente munición.");
        }
    }

    public void PerderVida()
    {
        if (vidasJugador > 0)
        {
            vidasJugador--;
            Debug.Log("vidas:" + vidasJugador);
            ActualizarUI();
        }
        else
        {
            Debug.Log("¡Game Over!");
            //Para acabar el juego (A futuro)
        }
    }

    public bool TieneSuficientesLlaves(int cantidadRequerida)
    {
        return llavesJugador >= cantidadRequerida;
    }

    private void ActualizarUI()
    {
        if (llavesText) llavesText.text = llavesJugador.ToString();
        if (vidasText) vidasText.text = vidasJugador.ToString();
        if (municionText) municionText.text = municionJugador.ToString();
        if (monedasText) monedasText.text = monedasJugador.ToString();
    }
}
