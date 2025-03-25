using UnityEngine;

public class ColisionTrampas : MonoBehaviour
{
    private Animator[] animators; // Guardará todos los animadores de los pinchos

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
            Debug.Log("La trampa tocó al jugador");
            VidasJugador jugador = other.GetComponent<VidasJugador>();
            if (jugador != null)
            {
                jugador.PerderVida(1);
            }
        }
    }

    void ActivateTrap()
    {
        foreach (Animator anim in animators)
        {
            anim.SetTrigger("Activate"); // Activa la animación en todos los pinchos
        }
    }
}
