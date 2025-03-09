using UnityEngine;

public class ColisionProyectil : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
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
