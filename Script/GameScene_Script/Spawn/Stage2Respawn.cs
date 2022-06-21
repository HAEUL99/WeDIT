using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Respawn : MonoBehaviour
{
    //스폰 포인트2
    public GameObject spawn2;
    //스폰포인트3
    public GameObject spawn3;
    //플레이어
    public GameObject player;
    //현재 큐브에 떨어지면 어디로 스폰할지를 int값으로 알림
    public int spawnPoint;


    private void Start()
    {
        spawnPoint = 2;
    }

    private void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Player" && spawnPoint == 2)
        {
            player = col.gameObject;
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, spawn2.transform.position.z);
            player.GetComponent<CharacterController>().enabled = true;
        }
        if (col.tag == "Player" && spawnPoint == 3)
        {
            player = col.gameObject;
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = new Vector3(spawn3.transform.position.x, spawn3.transform.position.y, spawn3.transform.position.z);
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
