using UnityEngine;
using UnityEngine.AI;

public class IAenemigos : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private bool persiguiendo = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (persiguiendo && player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    public void ActivarPersecución(Transform objetivo)
    {
        player = objetivo;
        persiguiendo = true;
        Debug.Log(gameObject.name + " ha comenzado la persecución.");
    }
}
