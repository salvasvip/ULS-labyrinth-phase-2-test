using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy1 : MonoBehaviour
{
    NavMeshAgent agent;
    private bool inAttackRange, inPersecutionRange;
    public LiveCharacter live;
    [SerializeField] int damagePlayer = 5;
    [SerializeField] GameObject Player;
    [SerializeField] float attackRadius = 2.0f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(Player.transform.position);
            inAttackRange = Vector3.Distance(transform.position, Player.transform.position) < attackRadius;
            if (inAttackRange)
            {
                live.PlayerHealth(damagePlayer);
                StartCoroutine("TImeToLive");
            }
    }

    IEnumerator TImeToLive()
    {
        yield return new WaitForSeconds(3);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
