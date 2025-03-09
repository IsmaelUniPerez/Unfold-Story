using System.Collections.Generic;
using UnityEngine;

public class ActivaciónEnemigos : MonoBehaviour
{
    [SerializeField] private List<IAenemigos> enemigosAsociados; // Lista de enemigos a activar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador")) // Detecta al jugador por su tag
        {
            foreach (IAenemigos enemigo in enemigosAsociados)
            {
                if (enemigo != null)
                {
                    enemigo.ActivarPersecución(other.transform);
                }
            }
        }
    }
}
