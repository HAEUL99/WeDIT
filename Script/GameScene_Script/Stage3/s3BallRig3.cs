using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s3BallRig3 : MonoBehaviour
{
    public Rigidbody s3ball3Rigidbody;
    s3Ball3 s3ball3;
    // Start is called before the first frame update
    void Start()
    {
        s3ball3 = GameObject.Find("ball3check").GetComponent<s3Ball3>();
        s3ball3Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (s3ball3.iss3ball3 == true)
        {
            s3ball3Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            s3ball3Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
        if (collision.gameObject.tag == "s3ballcheck3")
        {
            s3ball3Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }

    }
}
