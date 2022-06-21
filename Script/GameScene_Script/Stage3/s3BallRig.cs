using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s3BallRig : MonoBehaviour
{
    public Rigidbody s3ball1Rigidbody;
    s3Ball1 s3ball1;
    // Start is called before the first frame update
    void Start()
    {
        s3ball1 = GameObject.Find("ball1check").GetComponent<s3Ball1>();
        s3ball1Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (s3ball1.iss3ball1 == true)
        {
            s3ball1Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            s3ball1Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
        if (collision.gameObject.tag == "s3ballcheck1")
        {
            s3ball1Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}
