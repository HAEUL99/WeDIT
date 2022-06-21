using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s4Wall : Photon.Bolt.GlobalEventListener
{
    public GameObject s4wall;
    s4flowerleft s4Flowerleft;
    // Start is called before the first frame update
    void Start()
    {
        s4Flowerleft = GameObject.Find("clearleft").GetComponent<s4flowerleft>();
    }

    // Update is called once per frame
    void Update()
    {
        if (s4Flowerleft.s4cleared == true)
        {
            s4wall.SetActive(false);
        }
    }
    public override void OnEvent(Stage4ClearEvt evnt)
    {
        if (evnt.isS4Clear == true)
        {
            s4wall.SetActive(false);
        }
    }
}
