using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;


public class s3Ball2 : Photon.Bolt.GlobalEventListener
{
    public bool iss3ball2 = false;
    Renderer s3Ball2checkColor;
    // Start is called before the first frame update
    void Start()
    {
        s3Ball2checkColor = gameObject.GetComponent<Renderer>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("s3ball2"))
        {
            var stage3BallEvt = Stage3BallEvt.Create();
            stage3BallEvt.isS3Ball2 = true;
            stage3BallEvt.Send();
            iss3ball2 = true;
            s3Ball2checkColor.material.color = Color.red;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("s3ball2"))
        {
            iss3ball2 = true;
            s3Ball2checkColor.material.color = Color.black;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "ball2")
        {
            var stage3BallEvt = Stage3BallEvt.Create();
            stage3BallEvt.isS3Ball2 = false;
            stage3BallEvt.Send();
            iss3ball2 = false;
            s3Ball2checkColor.material.color = Color.white;
        }
    }
}
