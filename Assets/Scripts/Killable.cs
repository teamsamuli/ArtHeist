using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public float health = 100f;
    public float minforce = 11f;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.relativeVelocity.magnitude > minforce)
        {
            TakeDamage(50);
        }
    }



    public void TakeDamage (float amount)
    {
        health -= amount;
        if ( health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
