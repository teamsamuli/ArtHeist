using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    Guard guard;
    PlayerMovement player;

    public float health = 100f;
    public float noDMG = 20f;
    public float smallDMG = 10f;
    public float maxDMG = 0f;

    void Start()
    {
        guard = GetComponent<Guard>();
        player = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Dont do this if player
        if (player != null)
            return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Objects"))
        {
            Debug.Log("Took damage :D");

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
