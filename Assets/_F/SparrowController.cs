using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

public class SparrowController : MonoBehaviour
{
    public float groundSpeed = 3.5f;
    public float minFlyForce = 200f;
    public float maxFlyForce = 400f;
    public float minFlyTime = 3.0f;
    public float maxFlyTime = 7.0f;
    public float minIdleTime = 1.0f;
    public float maxIdleTime = 3.0f;

    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rb;
    private bool isFlying = false;
    private Vector3 initialPosition;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        initialPosition = transform.position;
        rb.isKinematic = true;

        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);

        StartCoroutine(BehaviorRoutine());
    }

    IEnumerator BehaviorRoutine()
    {
        while (true)
        {
            isFlying = false;
            agent.enabled = true;
            rb.isKinematic = true;
            rb.useGravity = false;
            agent.speed = groundSpeed;
            animator.SetBool("isFlying", false);

            Vector3 groundTarget;
            if (GetRandomPointOnNavMesh(out groundTarget))
            {
                agent.SetDestination(groundTarget);
                animator.SetBool("isWalking", true);

                while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
                {
                    yield return null;
                }

                animator.SetBool("isWalking", false);
            }

            animator.SetBool("isIdle", true);
            yield return new WaitForSeconds(Random.Range(minIdleTime, maxIdleTime));
            animator.SetBool("isIdle", false);

            isFlying = true;
            agent.enabled = false;
            rb.isKinematic = false;
            rb.useGravity = true;
            animator.SetBool("isFlying", true);

            float flyForce = Random.Range(minFlyForce, maxFlyForce);
            Vector3 flyDirection = new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f)).normalized;
            rb.AddForce(flyDirection * flyForce);

            float flyTime = Random.Range(minFlyTime, maxFlyTime);
            yield return new WaitForSeconds(flyTime);

            while (isFlying)
            {
                if (rb.velocity.magnitude < 0.1f && agent.enabled == false)
                {
                    isFlying = false;
                    rb.isKinematic = true;
                    rb.useGravity = false;
                    agent.enabled = true;

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

    void OnGrabbed(XRBaseInteractor interactor)
    {
        StopAllCoroutines();
        agent.enabled = false;
        rb.isKinematic = false;
        rb.useGravity = true;
        animator.SetBool("isFlying", true);
    }

    void OnReleased(XRBaseInteractor interactor)
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        animator.SetBool("isFlying", true);
        StartCoroutine(DelayedReenableNavMeshAgent());
    }

    IEnumerator DelayedReenableNavMeshAgent()
    {
        yield return new WaitForSeconds(10);
        rb.isKinematic = true;
        rb.useGravity = false;
        animator.SetBool("isFlying", false);
        agent.enabled = true;
        StartCoroutine(BehaviorRoutine());
    }
}
