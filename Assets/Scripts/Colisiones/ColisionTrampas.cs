using UnityEngine;

public class ColisionTrampas : MonoBehaviour
{
    private Animator[] animators; // Guardar� todos los animadores de los pinchos

    void Start()
    {
        // Obtiene todos los animadores de los hijos (PinchoPivote)
        animators = GetComponentsInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            ActivateTrap();
            Debug.Log("La trampa toc� al jugador");
            if (EfectosDeSonido.instance != null)
            {
                EfectosDeSonido.instance.TrampaActivada();
            }
            InventarioJugador jugador = other.GetComponent<InventarioJugador>();
            if (jugador != null)
            {
                jugador.PerderVida();
            }
        }
    }

    void ActivateTrap()
    {
        foreach (Animator anim in animators)
        {
            anim.SetTrigger("Activate"); // Activa la animaci�n en todos los pinchos
        }
    }
}
