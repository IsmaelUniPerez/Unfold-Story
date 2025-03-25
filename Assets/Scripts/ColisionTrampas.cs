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
