using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;



public class FirstSpawn : Photon.Bolt.GlobalEventListener
{
    private GameObject startSpawnPoint;
    private BoxCollider area;
    GameObject character;
    GameObject contentscharacter;
    GameObject playerCam;

    private GameObject headCam;
    private GameObject overheadCam;
    
    /*
    public override void SceneLoadLocalDone(string scene, IProtocolToken token)
    {
        
        startSpawnPoint = GameObject.Find("StartSpawnPoint");
        area = startSpawnPoint.GetComponent<BoxCollider>();

        for (int i = 0; i < 4; i++)
        {
            Spawn();
        }




        // instantiate cube
        //BoltNetwork.Instantiate(BoltPrefabs.Cube, spawnPosition, Quaternion.identity);
    }
    */

    public void Start()
    {
        startSpawnPoint = GameObject.Find("SpawnPoint1");
        area = startSpawnPoint.GetComponent<BoxCollider>();

        overheadCam = GameObject.FindGameObjectWithTag("Main Camera");
        overheadCam.SetActive(false);


        Spawn();
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = startSpawnPoint.transform.position;
        Vector3 size = area.size;

        // StartSpawnPoint 기준 인근값 
        var spawnPosition = new Vector3(Random.Range(-16, 16), 0, Random.Range(-16, 16));
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z;

        Vector3 spawnPos = new Vector3(posX, posY, posZ);
        return spawnPos;
    }

    private void Spawn()
    {
        character = Resources.Load<GameObject>($"UI_pref/CustomizeChar/{PlayerCharacter.ModelName}");
        headCam = Resources.Load<GameObject>($"UI_pref/CustomizeChar/{PlayerCharacter.ModelName}");
        Vector3 spawnPos = GetRandomPosition();

        contentscharacter = BoltNetwork.Instantiate(character, spawnPos, Quaternion.identity);
        //playerCam = BoltNetwork.Instantiate("PlayerCam", contentscharacter.transform, Quaternion.identity);
    }
}
