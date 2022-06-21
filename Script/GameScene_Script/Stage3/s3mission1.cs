using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s3mission1 : Photon.Bolt.GlobalEventListener
{
    Renderer s3Mission1Color;
    public bool s3misiion1clear = false;
    // Start is called before the first frame update
    void Start()
    {
        s3Mission1Color = gameObject.GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("s3hat1"))
        {
            var stage3ClearEvt = Stage3ClearEvt.Create();
            stage3ClearEvt.isS3Mission1 = true;
            stage3ClearEvt.Send();
            s3Mission1Color.material.color = Color.red;
            s3misiion1clear = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("s3hat1"))
        {
            s3Mission1Color.material.color = Color.red;
            s3misiion1clear = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("s3hat1"))
        {
            var stage3ClearEvt = Stage3ClearEvt.Create();
            stage3ClearEvt.isS3Mission1 = false;
            stage3ClearEvt.Send();
            s3Mission1Color.material.color = Color.white;
            s3misiion1clear = false;
        }
    }
}
