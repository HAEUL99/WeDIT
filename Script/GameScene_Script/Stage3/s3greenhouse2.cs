using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s3greenhouse2 : MonoBehaviour
{
    s3Ball1 s3ball1;
    s3Ball2 s3ball2;
    s3Ball3 s3ball3;
    public GameObject s3Greenhouse2;
    public Rigidbody s3greenhouserig2;
    // Start is called before the first frame update
    void Start()
    {
        s3greenhouserig2 = GetComponent<Rigidbody>();
        s3ball1 = GameObject.Find("ball1check").GetComponent<s3Ball1>();
        s3ball2 = GameObject.Find("ball2check").GetComponent<s3Ball2>();
        s3ball3 = GameObject.Find("ball3check").GetComponent<s3Ball3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (s3ball1.iss3ball1 == true && s3ball2.iss3ball2 == true && s3ball3.iss3ball3 == true)
        {
            Debug.Log("true");
            s3Greenhouse2.transform.Translate(0.05f, 0, 0);
            if (s3Greenhouse2.transform.position.y >= 5.0f)
            {
                transform.position = new Vector3(transform.position.x, 5.0f, transform.position.z);
                s3greenhouserig2.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
        }
        else
        {
            Debug.Log("false");
            if (s3Greenhouse2.transform.position.y >= 1.5f)
            {
                s3greenhouserig2.constraints = RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                s3Greenhouse2.transform.Translate(0, -0.05f, 0);
                if (s3Greenhouse2.transform.position.y <= 1.5f)
                {
                    transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
                }
            }
        }
    }
}
