using UnityEngine;

public class ColisionEnemigo : MonoBehaviour
{
    // Prefabs de los objetos que pueden ser soltados
    public GameObject corazonPrefab;
    public GameObject municionPrefab;
    public GameObject monedaPrefab;

    public float elevacion = 2f;  // La altura adicional en el eje Y

    // Probabilidades ajustables para cada tipo de dropeo
    [Range(0f, 1f)]
    public float probabilidadCorazon = 0.2f;   // 20% de posibilidad de soltar una llave
    [Range(0f, 1f)]
    public float probabilidadMunicion = 0.5f; // 50% de posibilidad de soltar munición
    [Range(0f, 1f)]
    public float probabilidadMoneda = 0.3f;   // 30% de posibilidad de soltar una moneda

    private void OnTriggerEnter(Collider other)
    {
        // Si el enemigo es destruido por un proyectil
        if (other.CompareTag("Proyectil"))
        {
            Debug.Log("El enemigo ha sido destruido por un proyectil.");
            SoltarObjeto(); // Llama a la función para soltar un objeto

            if (EfectosDeSonido.instance != null)
            {
                EfectosDeSonido.instance.EnemigoDestruido();
            }

            Destroy(gameObject); // Destruye el enemigo
        }

        // Si el enemigo toca al jugador, quita una vida al jugador
        if (other.CompareTag("Jugador"))
        {
            Debug.Log("El enemigo tocó al jugador");
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();
            if (inventario != null)
            {
                if (EfectosDeSonido.instance != null)
                {
                    EfectosDeSonido.instance.JugadorRecibeDanio();
                }
                inventario.PerderVida(); // Llamamos al método PerderVida del InventarioJugador
            }
        }
    }

    // Función para soltar objetos con probabilidades ajustables
    private void SoltarObjeto()
    {
        float totalProbabilidad = probabilidadCorazon + probabilidadMunicion + probabilidadMoneda;
        if (totalProbabilidad > 1f)
        {
            Debug.LogWarning("Las probabilidades no suman 1.0. Ajustando las probabilidades.");
            probabilidadCorazon /= totalProbabilidad;
            probabilidadMunicion /= totalProbabilidad;
            probabilidadMoneda /= totalProbabilidad;
        }

        float randomValue = Random.value; // Genera un valor aleatorio entre 0 y 1

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + elevacion, transform.position.z);

        // Si el valor aleatorio es menor que la probabilidad del corazon
        if (randomValue < probabilidadCorazon)
        {
            Instantiate(corazonPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("El enemigo soltó un corazón.");
        }
        // Si el valor aleatorio es menor que la probabilidad de munición
        else if (randomValue < probabilidadCorazon + probabilidadMunicion)
        {
            Instantiate(municionPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("El enemigo soltó munición.");
        }
        // Si el valor aleatorio es menor que la probabilidad de moneda
        else if (randomValue < probabilidadCorazon + probabilidadMunicion + probabilidadMoneda)
        {
            Instantiate(monedaPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("El enemigo soltó una moneda.");
        }
    }
}
