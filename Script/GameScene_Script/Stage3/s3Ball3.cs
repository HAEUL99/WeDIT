using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s3Ball3 : Photon.Bolt.GlobalEventListener
{
    public bool iss3ball3 = false;
    Renderer s3Ball3checkColor;
    // Start is called before the first frame update
    void Start()
    {
        s3Ball3checkColor = gameObject.GetComponent<Renderer>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("s3ball3"))
        {
            var stage3BallEvt = Stage3BallEvt.Create();
            stage3BallEvt.isS3Ball3 = true;
            stage3BallEvt.Send();
            iss3ball3 = true;
            s3Ball3checkColor.material.color = Color.red;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("s3ball3"))
        {
            iss3ball3 = true;
            s3Ball3checkColor.material.color = Color.black;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "ball3")
        {
            var stage3BallEvt = Stage3BallEvt.Create();
            stage3BallEvt.isS3Ball3 = false;
            stage3BallEvt.Send();
            iss3ball3 = false;
            s3Ball3checkColor.material.color = Color.white;
        }
    }
}
