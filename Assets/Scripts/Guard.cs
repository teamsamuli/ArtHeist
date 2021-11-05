using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    List<Rigidbody> limbs = new List<Rigidbody>();
    List<Collider> cols = new List<Collider>();

    public float speed = 5f;
    public float angularSpeed = 360f;
    public float attackDelay = 0.5f;

    bool attacking;
    bool isAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get components
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        //Get limb rigidbodies
        foreach(Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            if (!limbs.Contains(rb)) limbs.Add(rb);

            rb.isKinematic = true;
        }

        //Get limb colliders
        foreach(Collider col in GetComponentsInChildren<Collider>())
        {
            if (!cols.Contains(col)) cols.Add(col);

            col.isTrigger = true;
        }

        //Setup stats for agent
        agent.speed = speed;
        agent.angularSpeed = angularSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Moving", IsMoving());

        //Debug keys
        if (Input.GetKeyDown(KeyCode.W))
            SetTargetDestination(new Vector3(10, 0, 0));
        else if (Input.GetKeyDown(KeyCode.S))
            SetTargetDestination(new Vector3(0, 0, 10));
        else if (Input.GetKeyDown(KeyCode.Space))
            Attack();
        else if (Input.GetKeyDown(KeyCode.K))
            Die();
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

    public void Die()
    {
        isAlive = false;
        anim.enabled = false;
        agent.enabled = false;

        EnableRagdoll();
    }

    void EnableRagdoll()
    {
        //Make rigidbodies react to physics
        foreach(Rigidbody rb in limbs)
        {
            rb.isKinematic = false;
        }

        //Make colliders collide
        foreach(Collider col in cols)
        {
            col.isTrigger = false;
        }
    }
}
