using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public GameObject ProyectilPrefab;
    public float velocidadProyectil = 10f;
    public Transform puntoDeDisparo;

    private Vector3 direccionDeMovimiento;
    private InventarioJugador inventario;

    void Start()
    {
        inventario = FindFirstObjectByType<InventarioJugador>();
    }

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
        if (inventario != null && inventario.municionJugador > 0)
        {
            if (direccionDeMovimiento.magnitude > 0)
            {
                GameObject proyectil = Instantiate(ProyectilPrefab, puntoDeDisparo.position, Quaternion.identity);
                Rigidbody rb = proyectil.GetComponent<Rigidbody>();
                Debug.Log("He disparado");

                rb.linearVelocity = direccionDeMovimiento * velocidadProyectil; // Corrección: usar rb.velocity

                inventario.UsarMunicion(1); // Restar 1 de munición
            }
        }
        else
        {
            Debug.Log("No tienes munición suficiente.");
        }
    }
}
