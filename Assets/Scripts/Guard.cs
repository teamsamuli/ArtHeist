using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    public float speed = 5f;
    public float angularSpeed = 360f;
    public float attackDelay = 0.5f;

    bool attacking;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.speed = speed;
        agent.angularSpeed = angularSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Moving", IsMoving());

        if (Input.GetKeyDown(KeyCode.W))
            SetTargetDestination(new Vector3(10, 0, 0));
        else if (Input.GetKeyDown(KeyCode.S))
            SetTargetDestination(new Vector3(0, 0, 10));
        else if (Input.GetKeyDown(KeyCode.Space))
            Attack();
    }

    bool IsMoving()
    {
        if (agent.velocity.magnitude > 0.2f)
            return true;

        return false;
    }

    public void SetTargetDestination(Vector3 targetPos)
    {
        agent.SetDestination(targetPos);
    }

    public void Attack()
    {
        if (!attacking)
            StartCoroutine(StartAttacking());
    }

    IEnumerator StartAttacking()
    {
        anim.SetTrigger("Attack");
        agent.speed = 0;
        attacking = true;

        yield return new WaitForSeconds(attackDelay);

        agent.speed = speed;
        attacking = false;
    }
}
