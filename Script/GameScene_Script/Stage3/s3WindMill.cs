using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class s3WindMill : Photon.Bolt.GlobalEventListener
{
    Button2Click button2click;
    public GameObject s3windmill;
    public bool iss3windmill = false;
    // Start is called before the first frame update
    void Start()
    {
        button2click = GameObject.Find("DoorButton2").GetComponent<Button2Click>();
        var stage3ButtonEvt = Stage3ButtonEvt.Create();
    }

    // Update is called once per frame
    void Update()
    {
        if (button2click.s3button2clicked == true)
        {
            var stage3ButtonEvt = Stage3ButtonEvt.Create();
            stage3ButtonEvt.isS3WindMill = true;
            stage3ButtonEvt.Send();
            s3windmill.transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime);
            iss3windmill = true;
        }
    }

    public override void OnEvent(Stage3ButtonEvt evnt)
    {
        if (evnt.s3Button2Clicked == true)
        {
            s3windmill.transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime);
            iss3windmill = true;
        }
    }
}
