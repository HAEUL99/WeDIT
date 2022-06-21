using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s3mission2 : Photon.Bolt.GlobalEventListener
{
    Renderer s3Mission2Color;
    public bool s3misiion2clear = false;
    // Start is called before the first frame update
    void Start()
    {
        s3Mission2Color = gameObject.GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("s3hat2"))
        {
            var stage3ClearEvt = Stage3ClearEvt.Create();
            stage3ClearEvt.isS3Mission2 = true;
            stage3ClearEvt.Send();
            s3Mission2Color.material.color = Color.red;
            s3misiion2clear = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("s3hat2"))
        {
            s3Mission2Color.material.color = Color.red;
            s3misiion2clear = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("s3hat2"))
        {
            var stage3ClearEvt = Stage3ClearEvt.Create();
            stage3ClearEvt.isS3Mission2 = false;
            stage3ClearEvt.Send();
            s3Mission2Color.material.color = Color.white;
            s3misiion2clear = false;
        }
    }
}
