using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s3BallRig2 : MonoBehaviour
{
    public Rigidbody s3ball2Rigidbody;
    s3Ball2 s3ball2;
    // Start is called before the first frame update
    void Start()
    {
        s3ball2 = GameObject.Find("ball2check").GetComponent<s3Ball2>();
        s3ball2Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (s3ball2.iss3ball2 == true)
        {
            s3ball2Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            s3ball2Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
        if (collision.gameObject.tag == "s3ballcheck2")
        {
            s3ball2Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
}
