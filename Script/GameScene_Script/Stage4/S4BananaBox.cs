using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class S4BananaBox : Photon.Bolt.GlobalEventListener
{
    public bool s4bananayes = false;
    Renderer s4Bananacolor;
    // Start is called before the first frame update
    void Start()
    {
        s4Bananacolor = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("s4banana"))
        {
            var stage4ClearEvt = Stage4ClearEvt.Create();
            stage4ClearEvt.isS4BananaBox = true;
            stage4ClearEvt.Send();
            s4bananayes = true;
            s4Bananacolor.material.color = Color.yellow;
        }
    }
}
