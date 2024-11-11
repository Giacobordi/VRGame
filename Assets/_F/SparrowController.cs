using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SparrowController : MonoBehaviour
{
    public float groundSpeed = 3.5f;
    public float minFlyForce = 200f; // Minima forza di volo
    public float maxFlyForce = 400f; // Massima forza di volo
    public float minFlyTime = 3.0f;
    public float maxFlyTime = 7.0f;
    public float minIdleTime = 1.0f;
    public float maxIdleTime = 3.0f;

    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rb;
    private bool isFlying = false;
    private Vector3 initialPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position; // Salva la posizione iniziale
        rb.isKinematic = true; // Disabilita la fisica all'inizio
        StartCoroutine(BehaviorRoutine());
    }

    IEnumerator BehaviorRoutine()
    {
        while (true)
        {
            // Fase di movimento a terra
            isFlying = false;
            agent.enabled = true;
            rb.isKinematic = true; // Disabilita la fisica
            rb.useGravity = false;
            agent.speed = groundSpeed;
            animator.SetBool("isFlying", false);

            // Muoviti verso un punto casuale sulla NavMesh
            Vector3 groundTarget;
            if (GetRandomPointOnNavMesh(out groundTarget))
            {
                agent.SetDestination(groundTarget);
                animator.SetBool("isWalking", true);

                // Aspetta finché non raggiunge la destinazione
                while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
                {
                    yield return null;
                }

                animator.SetBool("isWalking", false);
            }

            // Fase di inattività
            animator.SetBool("isIdle", true);
            yield return new WaitForSeconds(Random.Range(minIdleTime, maxIdleTime));
            animator.SetBool("isIdle", false);

            // Fase di volo
            isFlying = true;
            agent.enabled = false;
            rb.isKinematic = false; // Abilita la fisica
            rb.useGravity = true;
            animator.SetBool("isFlying", true);

            // Lancia l'uccellino in aria con una forza casuale tra minFlyForce e maxFlyForce
            float flyForce = Random.Range(minFlyForce, maxFlyForce);
            Vector3 flyDirection = new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f)).normalized;
            rb.AddForce(flyDirection * flyForce);

            // Aspetta per un tempo casuale
            float flyTime = Random.Range(minFlyTime, maxFlyTime);
            yield return new WaitForSeconds(flyTime);

            // Discesa e atterraggio
            while (isFlying)
            {
                if (rb.velocity.magnitude < 0.1f && agent.enabled == false) // Controlla se l'uccellino è fermo
                {
                    isFlying = false;
                    rb.isKinematic = true; // Disabilita la fisica
                    rb.useGravity = false;
                    agent.enabled = true;

                    // Assicurati che l'uccellino sia sulla NavMesh
                    if (!agent.isOnNavMesh)
                    {
                        Vector3 validPosition;
                        if (GetRandomPointOnNavMesh(out validPosition))
                        {
                            agent.Warp(validPosition);
                        }
                    }
                }
                yield return null;
            }
        }
    }

    bool GetRandomPointOnNavMesh(out Vector3 result)
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            agent.Warp(initialPosition);
        }
    }
}
