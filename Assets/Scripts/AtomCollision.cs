using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomCollision : MonoBehaviour
{
    [SerializeField] Transform proton;
    [SerializeField] Transform neutron;
    private Rigidbody rb;
    [SerializeField] float maxRepulsionForce = 10.0f;
    [SerializeField] float repulsionRadius = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        float distanceToProton = Vector3.Distance(transform.position, proton.position);
        float distanceToNeutron = Vector3.Distance(transform.position, neutron.position);

        
        Transform closestSphere = distanceToProton < distanceToNeutron ? proton : neutron;

        
        Vector3 repulsionDirection = (transform.position - closestSphere.position).normalized;

        
        if (distanceToProton < repulsionRadius || distanceToNeutron < repulsionRadius)
        {
                
            float repulsionForce = Mathf.Clamp(maxRepulsionForce / (distanceToProton * distanceToProton), 0, maxRepulsionForce);

        
            rb.AddForce(repulsionDirection * repulsionForce);
        }
    }
    
}
