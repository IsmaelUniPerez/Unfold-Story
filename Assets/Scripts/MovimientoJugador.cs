using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float speed = 10.0F; //Velocidad de movimiento
    public float rotationSpeed = 100.0F; //Velocidad de rotación

    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

    }
    //Como mola este otro movimiento
    /*
    public Rigidbody rb;
    public float velocidad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH * velocidad, 0.0f, movimientoV * velocidad);
        rb.AddForce(movimiento);
    }*/
}
