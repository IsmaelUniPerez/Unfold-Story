using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float speed = 10.0f;
    private Animator anim;
    // Ok esto es para voltear el sprite
    public Transform visual; // Primero le digo el sprite que es, que este es el objeto con todo lo del jugador
    public Transform boneToFlip;  // Aquí voy a decirle el hueso al que le voy a hacer flip, como quiero voltear tooo el personaje voy a seleccionar el principal

    void Start()
    {
        // Primero que recoga toda la info del animator
        anim = GetComponent<Animator>();

        if (visual == null || boneToFlip == null) // Para asegurarnos de que no funcione si no están los objetos asignados
        {
            Debug.LogError("No se ha asignado el objeto Visual o el hueso en el inspector.");
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (movement.magnitude > 0)
        {
            anim.SetBool("isMoving", true);
            // Detectamos que nos movemos a la derecha o izquierda
            if (moveX > 0)
            {
                boneToFlip.localScale = new Vector3(1, 1, 1);  // Hueso mirando a la derecha
                anim.SetFloat("moveX", 1); // Ajusta el parámetro para caminar a la derecha
            }
            else if (moveX < 0)
            {
                boneToFlip.localScale = new Vector3(1, -1, 1);  // Hueso mirando a la izquierda
                anim.SetFloat("moveX", -1); // Ajusta el parámetro para caminar a la izquierda
            }
        }
        else
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("moveX", 0); // Parámetro para cuando el personaje no se mueve
        }
    }
}