using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChar : MonoBehaviour
{
    private float rotationSpeed = 200f;
    private bool dragging = false;
    Rigidbody rb;
   

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnMouseDrag()
    {
        dragging = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    void FixedUpdate()
    {
        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;

            rb.AddTorque(Vector3.down * x * 2);

        }        
    }


}
