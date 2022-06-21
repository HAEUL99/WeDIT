using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Respawn : MonoBehaviour
{
    //스폰 포인트 4
    public GameObject spawn4;
    //플레이어
    public GameObject player;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            player = col.gameObject;
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = new Vector3(spawn4.transform.position.x, spawn4.transform.position.y, spawn4.transform.position.z);
            player.GetComponent<CharacterController>().enabled = true;
        }


    }
}
