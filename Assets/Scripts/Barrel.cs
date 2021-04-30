using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-speed, 0, 0);
    }

    private void Update()
    {
        if(rb.velocity.sqrMagnitude < 1f)
            rb.velocity = new Vector3(-speed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
