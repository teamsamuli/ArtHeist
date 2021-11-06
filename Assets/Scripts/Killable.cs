using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    Guard guard;

    public float health = 100f;
    public float noDMG = 20f;
    public float smallDMG = 10f;
    public float maxDMG = 0f;
    public LayerMask objectsMask;

    void Start()
    {
<<<<<<< Updated upstream
        if (collision.gameObject.layer == objectsMask)
=======
        guard = GetComponent<Guard>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > maxDMG )
        {
            TakeDamage(50);
        }
        else if (collision.relativeVelocity.magnitude < maxDMG && collision.relativeVelocity.magnitude > noDMG)
        {
            TakeDamage(20);
        }
        else if (collision.relativeVelocity.magnitude < noDMG)
>>>>>>> Stashed changes
        {
            if (collision.relativeVelocity.magnitude > maxDMG)
            {
                TakeDamage(50);
            }
            else if (collision.relativeVelocity.magnitude < maxDMG && collision.relativeVelocity.magnitude > noDMG)
            {
                TakeDamage(20);
            }
            else if (collision.relativeVelocity.magnitude < noDMG)
            {
                TakeDamage(0);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if ( health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (guard != null)
        {
            guard.Die();
        }
        else
        {
            Destroy(gameObject);
        }      
    }
}
