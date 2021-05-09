using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is to make sure we have a rigidbody
[RequireComponent(typeof(Rigidbody))]

public class CubePlayer : MonoBehaviour
{
    // a reference to the rigidbody
    Rigidbody rb; 
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody>();
    pos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Horizontal") * 50, 0, Input.GetAxis("Vertical") * 50);
    }

}
