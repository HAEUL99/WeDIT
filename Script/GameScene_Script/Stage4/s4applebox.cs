using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s4applebox : Photon.Bolt.GlobalEventListener
{
    public bool s4appleyes = false;
    Renderer s4Applecolor;
    // Start is called before the first frame update
    void Start()
    {
        s4Applecolor = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("s4apple"))
        {
            var stage4ClearEvt = Stage4ClearEvt.Create();
            stage4ClearEvt.isS4AppleBox = true;
            stage4ClearEvt.Send();
            s4appleyes = true;
            s4Applecolor.material.color = Color.red;
        }
    }
}
