using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearAttraction : MonoBehaviour
{
    [SerializeField] Transform target;
    private Rigidbody rb;
    [SerializeField] float attractionStrength = 10.0f;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float distance = direction.magnitude;

            if (distance > 0.1f)
            {
                Vector3 attractionForce = direction.normalized * attractionStrength;
                rb.AddForce(attractionForce);
            }
        }
    }
}

