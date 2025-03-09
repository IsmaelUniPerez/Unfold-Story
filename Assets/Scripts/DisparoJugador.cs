using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public GameObject ProyectilPrefab;
    public float velocidadProyectil = 10f;
    public Transform puntoDeDisparo;

    private Vector3 direccionDeMovimiento;

    void Update()
    {
        direccionDeMovimiento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        if (direccionDeMovimiento.magnitude > 0)
        {
            GameObject proyectil = Instantiate(ProyectilPrefab, puntoDeDisparo.position, Quaternion.identity);
            Rigidbody rb = proyectil.GetComponent<Rigidbody>();
            Debug.Log("He disparado");
            rb.linearVelocity = direccionDeMovimiento * velocidadProyectil;
        }
    }
}
