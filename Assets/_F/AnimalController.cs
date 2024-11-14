using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

public class AnimalController : MonoBehaviour
{
    public float groundSpeed = 3.5f;
    public float minJumpForce = 200f;
    public float maxJumpForce = 400f;
    public float minIdleTime = 1.0f;
    public float maxIdleTime = 3.0f;
    public float noKinematicTime = 1.0f; // Tempo durante il quale isKinematic rimane disattivato

    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rb;
    private bool isJumping = false;
    private bool kinematicCooldown = false; // Indica se il timer è attivo
    private Vector3 initialPosition;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        initialPosition = transform.position; // Salva la posizione iniziale
        rb.isKinematic = true; // Disabilita la fisica all'inizio

        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);

        StartCoroutine(BehaviorRoutine());
    }

    IEnumerator BehaviorRoutine()
    {
        while (true)
        {
            // Fase di movimento a terra
            isJumping = false;
            agent.enabled = true;
            rb.isKinematic = true; // Disabilita la fisica
            rb.useGravity = false;
            agent.speed = groundSpeed;

            // Muoviti verso un punto casuale sulla NavMesh
            Vector3 groundTarget;
            if (GetRandomPointOnNavMesh(out groundTarget))
            {
                agent.SetDestination(groundTarget);
                animator.SetBool("isWalking", true);

                // Aspetta finché l'agente è attivo e raggiunge la destinazione
                while (agent.isActiveAndEnabled && (agent.pathPending || (agent.isOnNavMesh && agent.remainingDistance > agent.stoppingDistance)))
                {
                    yield return null;
                }

                animator.SetBool("isWalking", false);
            }

            // Fase di inattività
            yield return new WaitForSeconds(Random.Range(minIdleTime, maxIdleTime));

            // Fase di salto casuale
            if (Random.value < 0.2f) // 20% di probabilità di saltare
            {
                Salta();
                yield return new WaitForSeconds(1.0f); // Attendi un po' prima di continuare il ciclo
            }
        }
    }

    void Salta()
    {
        isJumping = true;
        agent.enabled = false;
        rb.isKinematic = false; // Abilita la fisica
        rb.useGravity = true;
        kinematicCooldown = true; // Attiva il cooldown per isKinematic

        // Lancia l'animale in aria con una forza casuale tra minJumpForce e maxJumpForce
        float jumpForce = Random.Range(minJumpForce, maxJumpForce);
        Vector3 jumpDirection = new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f)).normalized;
        rb.AddForce(jumpDirection * jumpForce);

        Debug.Log("Salto eseguito: isKinematic disabilitato e forza applicata!");

        // Avvia coroutine per terminare il salto e il timer
        StartCoroutine(EndJump());
        StartCoroutine(ResetKinematicCooldown());
    }

    IEnumerator ResetKinematicCooldown()
    {
        yield return new WaitForSeconds(noKinematicTime);
        kinematicCooldown = false;
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
        Debug.Log("OnTriggerEnter chiamato con: " + other.gameObject.name);

        if (other.gameObject.tag == "Boundary")
        {
            agent.Warp(initialPosition);
        }
        else if (other.gameObject.tag == "Player" && !kinematicCooldown)
        {
            Debug.Log("Giocatore rilevato, lancio dell'animale!");

            // Animale spaventato, viene lanciato in fisica
            Salta();
        }
    }

    IEnumerator EndJump()
    {
        yield return new WaitUntil(() => rb.velocity.magnitude < 0.1f);

        isJumping = false;
        if (!kinematicCooldown) // Verifica se il cooldown è attivo
        {
            rb.isKinematic = true; // Disabilita la fisica
            rb.useGravity = false;
            agent.enabled = true;

            // Assicurati che l'animale sia sulla NavMesh
            if (!agent.isOnNavMesh)
            {
                Vector3 validPosition;
                if (GetRandomPointOnNavMesh(out validPosition))
                {
                    agent.Warp(validPosition);
                }
            }

            Debug.Log("Salto terminato: isKinematic abilitato e NavMeshAgent riattivato!");
        }
    }

    void OnGrabbed(XRBaseInteractor interactor)
    {
        StopAllCoroutines();
        agent.enabled = false;
        rb.isKinematic = false;
        rb.useGravity = true;
        animator.SetBool("isJumping", true);
    }

    void OnReleased(XRBaseInteractor interactor)
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        animator.SetBool("isJumping", true);
        StartCoroutine(DelayedReenableNavMeshAgent());
    }

    IEnumerator DelayedReenableNavMeshAgent()
    {
        yield return new WaitForSeconds(10);
        rb.isKinematic = true;
        rb.useGravity = false;
        animator.SetBool("isJumping", false);
        agent.enabled = true;
        StartCoroutine(BehaviorRoutine());
    }
}
