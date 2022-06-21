using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class SetlastCloud : Photon.Bolt.GlobalEventListener
{
    public bool Ischecked = false;
    public Animator animator;


    private void OnTriggerStay(Collider col)
    {
        if (Ischecked == false)
        {
            var cloudevnt = Stage2lastCloudEvnt.Create();
            cloudevnt.setAnim = true;
            cloudevnt.Send();
            Ischecked = true;
        }

    }

    public override void OnEvent(Stage2lastCloudEvnt evnt)
    {
        if (evnt.setAnim == true)
        {
            animator.SetBool("IsTrigger", true);
        }
    }

}
