using UnityEngine;

public class ColisionProyectil : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador")) // Lo he añadido para que ignore le collider del jugador
        {
            return;
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
