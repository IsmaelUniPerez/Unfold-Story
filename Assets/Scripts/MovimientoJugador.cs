using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float speed = 10.0f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
