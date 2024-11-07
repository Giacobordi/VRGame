using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SparrowController : MonoBehaviour
{
    public float groundSpeed = 3.5f;
    public float flySpeed = 6.0f;
    public float minFlyTime = 3.0f;
    public float maxFlyTime = 7.0f;
    public float minIdleTime = 1.0f;
    public float maxIdleTime = 3.0f;
    public float flyHeight = 10.0f;
    public float descendSpeed = 2.0f;
    public float minSeparationDistance = 2.0f;

    private NavMeshAgent agent;
    private Animator animator;
    private bool isFlying = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        StartCoroutine(BehaviorRoutine());
    }

    IEnumerator BehaviorRoutine()
    {
        while (true)
        {
            // Ground movement
            isFlying = false;
            agent.speed = groundSpeed;
            agent.enabled = true;
            animator.SetBool("isFlying", false);

            // Ensure the Sparrow is on the NavMesh
            if (!agent.isOnNavMesh)
            {
                Vector3 validPosition;
                if (GetRandomPointOnNavMesh(out validPosition))
                {
                    agent.Warp(validPosition);
                }
            }

            // Move to a random point on the NavMesh
            Vector3 groundTarget;
            if (agent.isActiveAndEnabled && GetRandomPointOnNavMesh(out groundTarget))
            {
                agent.SetDestination(groundTarget);
                // Walking animation
                animator.SetBool("isWalking", true);

                // Wait until it reaches the destination
                while (agent.isActiveAndEnabled && (agent.pathPending || agent.remainingDistance > agent.stoppingDistance))
                {
                    yield return null;
                }

                // Stop walking animation
                animator.SetBool("isWalking", false);
            }

            // Idle for a while
            animator.SetBool("isIdle", true);
            yield return new WaitForSeconds(Random.Range(minIdleTime, maxIdleTime));
            animator.SetBool("isIdle", false);

            // Fly up to a height in a parabolic trajectory
            isFlying = true;
            agent.enabled = false;
            animator.SetBool("isFlying", true);

            Vector3 flyDirection;
            Vector3 targetFlyPosition;
            do
            {
                flyDirection = GetRandomDirection();
                targetFlyPosition = new Vector3(transform.position.x + flyDirection.x * 10, flyHeight, transform.position.z + flyDirection.z * 10);
            } while (!IsPointOnNavMesh(targetFlyPosition));

            Vector3 startPosition = transform.position;
            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * flySpeed / Vector3.Distance(startPosition, targetFlyPosition);
                Vector3 parabolicPosition = ParabolicFlight(startPosition, new Vector3(targetFlyPosition.x, flyHeight, targetFlyPosition.z), t);
                RotateTowards(parabolicPosition - transform.position);
                transform.position = parabolicPosition;
                yield return null;
            }

            // Fly in the air for a while
            float flyTime = Random.Range(minFlyTime, maxFlyTime);
            Vector3 airTargetPosition;
            do
            {
                flyDirection = GetRandomDirection();
                airTargetPosition = new Vector3(targetFlyPosition.x + flyDirection.x * 10, targetFlyPosition.y, targetFlyPosition.z + flyDirection.z * 10);
            } while (!IsPointOnNavMesh(airTargetPosition));

            startPosition = transform.position;
            t = 0;
            while (t < 1)
            {
                t += Time.deltaTime / flyTime;
                Vector3 parabolicPosition = ParabolicFlight(startPosition, airTargetPosition, t);
                RotateTowards(parabolicPosition - transform.position);
                transform.position = parabolicPosition;
                yield return null;
            }

            // Descend to the ground in a parabolic trajectory
            if (GetRandomPointOnNavMesh(out groundTarget))
            {
                startPosition = transform.position;
                t = 0;
                while (t < 1)
                {
                    t += Time.deltaTime * descendSpeed / Vector3.Distance(startPosition, groundTarget);
                    Vector3 parabolicPosition = ParabolicFlight(startPosition, groundTarget, t);
                    RotateTowards(parabolicPosition - transform.position);
                    transform.position = parabolicPosition;
                    yield return null;
                }

                // Ensure the Sparrow is on the ground at the exact position
                transform.position = groundTarget;
            }
        }
    }

    void RotateTowards(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * flySpeed * 100);
        }
    }

    Vector3 ParabolicFlight(Vector3 start, Vector3 end, float t)
    {
        float height = Mathf.Sin(Mathf.PI * t) * flyHeight;
        Vector3 position = Vector3.Lerp(start, end, t);
        position.y += height;
        return position;
    }

    bool GetRandomPointOnNavMesh(out Vector3 result)
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas))
        {
            result = hit.position;
            if (!IsTooCloseToOtherSparrows(result))
            {
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    Vector3 GetRandomDirection()
    {
        return new Vector3(
            Random.Range(-1f, 1f),
            0,
            Random.Range(-1f, 1f)
        ).normalized;
    }

    bool IsPointOnNavMesh(Vector3 point)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(point, out hit, 1.0f, NavMesh.AllAreas);
    }

    bool IsTooCloseToOtherSparrows(Vector3 position)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, minSeparationDistance);
        foreach (var hitCollider in hitColliders)
        {
            SparrowController sparrow = hitCollider.GetComponent<SparrowController>();
            if (sparrow != null && sparrow != this)
            {
                return true;
            }
        }
        return false;
    }
}
