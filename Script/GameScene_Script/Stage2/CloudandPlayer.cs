using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudandPlayer : MonoBehaviour
{
    public ButtonGreen buttonGreen;
    //public GameObject flyingcloud;
    private Transform cloudtransform;

   

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            buttonGreen = GameObject.Find("S1greenButton").GetComponent<ButtonGreen>();

            cloudtransform = buttonGreen.cloud.transform.GetChild(3).GetComponent<Transform>();
            col.gameObject.transform.SetParent(cloudtransform);



        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.transform.SetParent(null);

        }

    }
}
