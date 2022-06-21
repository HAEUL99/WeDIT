using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCenterOfMass : MonoBehaviour
{

    //public Vector3 centerOfMass;


    private void Update()
    {
        //centerOfMass = Vector3.zero;
        GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
    }

    
    void OnDrawGizmos()
    {
        /*
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.1f);
        */
    }
    
    
}
