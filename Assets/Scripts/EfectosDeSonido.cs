using UnityEngine;

public class EfectosDeSonido : MonoBehaviour
{
    public static EfectosDeSonido instance; // Instancia estática para acceder desde otros scripts

    public AudioClip sonidoEnemigoDestruido;
    public AudioClip sonidoJugadorRecibeDanio;
    public AudioClip sonidoTrampaActivada;
    public AudioClip sonidoMoneda;
    public AudioClip sonidoVida;
    public AudioClip sonidoMunicion;
    public AudioClip sonidoLlave;
    private AudioSource audioSource; // Componente AudioSource

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Método para reproducir un sonido
    public void ReproducirSonido(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // Métodos para sonidos específicos
    public void EnemigoDestruido()
    {
        if (sonidoEnemigoDestruido != null)
        {
            ReproducirSonido(sonidoEnemigoDestruido);
        }
    }

    public void JugadorRecibeDanio()
    {
        if (sonidoJugadorRecibeDanio != null)
        {
            ReproducirSonido(sonidoJugadorRecibeDanio);
        }
    }

    public void TrampaActivada()
    {
        if (sonidoTrampaActivada != null)
        {
            ReproducirSonido(sonidoTrampaActivada);
        }
    }
    public void Moneda()
    {
        if (sonidoMoneda != null)
        {
            ReproducirSonido(sonidoMoneda);
        }
    }
    public void Vida()
    {
        if (sonidoVida != null)
        {
            ReproducirSonido(sonidoVida);
        }
    }
    public void Municion()
    {
        if (sonidoMunicion != null)
        {
            ReproducirSonido(sonidoMunicion);
        }
    }
    public void Llave()
    {
        if (sonidoLlave != null)
        {
            ReproducirSonido(sonidoLlave);
        }
    }
}
