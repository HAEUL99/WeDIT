using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2siderig : MonoBehaviour
{
    private Rigidbody s2siderigidbody;
    private GameObject s2sidelever;
    // Start is called before the first frame update
    void Start()
    {
        s2siderigidbody = GetComponent<Rigidbody>();
        s2sidelever = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (s2sidelever.transform.rotation.x > 0.35)
        {
            s2sidelever.transform.rotation = Quaternion.Euler(45,0,0);
        }
        if (s2sidelever.transform.rotation.x < -0.35)
        {
            s2sidelever.transform.rotation = Quaternion.Euler(-45, 0, 0);
        }
    }
}
