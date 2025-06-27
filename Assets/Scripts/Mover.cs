using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        UpdateAnimator();
    }

    public void MoveTo(Vector3 destination)
    {
        navMeshAgent.destination = destination;
        navMeshAgent.isStopped = false;
    }

    public void Move(Vector3 hit, bool isDead)
    {
        if (isDead) return;
        GetComponent<NavMeshAgent>().destination = hit;
    }

    public void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        if(GetComponent<PlayerController>())GetComponentInChildren<Animator>().SetFloat("forwardSpeed", speed);
    }

    public void StartMove(Vector3 destination)
    {
        GetComponent<Fighter>().Cancel();
        MoveTo(destination);
    }

    public void Stop()
    {
        navMeshAgent.isStopped = true;
    }
}