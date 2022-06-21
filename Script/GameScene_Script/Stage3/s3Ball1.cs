using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s3Ball1 : Photon.Bolt.GlobalEventListener
{
    public bool iss3ball1 = false;
    Renderer s3Ball1checkColor;
    // Start is called before the first frame update
    void Start()
    {
        s3Ball1checkColor = gameObject.GetComponent<Renderer>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("s3ball1"))
        {
            //Debug.Log("ball enter");
            var stage3BallEvt = Stage3BallEvt.Create();
            stage3BallEvt.isS3Ball1 = true;
            stage3BallEvt.Send();
            iss3ball1 = true;
            s3Ball1checkColor.material.color = Color.red;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("s3ball1"))
        {
            //Debug.Log("ball stay");
            iss3ball1 = true;
            s3Ball1checkColor.material.color = Color.black;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "ball1")
        {
            var stage3BallEvt = Stage3BallEvt.Create();
            stage3BallEvt.isS3Ball1 = false;
            stage3BallEvt.Send();
            //Debug.Log("ball exit");
            iss3ball1 = false;
            s3Ball1checkColor.material.color = Color.white;
        }
    }
}
