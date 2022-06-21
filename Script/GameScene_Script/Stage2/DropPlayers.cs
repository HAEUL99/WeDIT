using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlayers : MonoBehaviour
{
    public ButtonGreen buttongreen;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "flyingcloud")
        {
            Debug.Log("닿음");

            //Invoke("buttongreen.Detroycloud", 2.0f);
            buttongreen.Detroycloud();
            //Invoke("buttongreen.NewCloudInstantiate", 4.0f);
            buttongreen.NewCloudInstantiate();
        }
    }


}
