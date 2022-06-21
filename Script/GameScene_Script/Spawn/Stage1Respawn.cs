using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Respawn : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject player;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            player = col.gameObject;
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = new Vector3(spawn1.transform.position.x, spawn1.transform.position.y, spawn1.transform.position.z);
            player.GetComponent<CharacterController>().enabled = true;
        }
    }


}
