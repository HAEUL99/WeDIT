using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class DetectCarArrive : Photon.Bolt.GlobalEventListener
{
    public GameObject doors;
    //public GameObject car;
    private Animator anim;

    private void Start()
    {
        anim = doors.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // event
        if (other.tag == "Car")
        {
            Invoke("OpentheDoor", 2.0f); 
        }
    }

    private void OpentheDoor()
    {
        /*
        if (BoltNetwork.IsServer)
        {
            bool IsArrive = true;
            anim.SetBool("IsArrive", IsArrive);
        }
        */
        
        bool IsArrive = true;
        anim.SetBool("IsArrive", IsArrive);
        
    }
}
