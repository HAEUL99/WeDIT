using System.Collections;
using System.Collections.Generic;
using Photon.Bolt;
using UnityEngine;


public class FirsSpawnTest : Photon.Bolt.GlobalEventListener
{
    private GameObject startSpawnPoint;
    private BoxCollider area;
    GameObject character;
    GameObject contentscharacter;


    public void Start()
    {
        startSpawnPoint = GameObject.Find("SpawnPoint1");
        area = startSpawnPoint.GetComponent<BoxCollider>();

        Spawn();
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = startSpawnPoint.transform.position;
        Vector3 size = area.size;


       float range_X = area.bounds.size.x;
       float range_Z = area.bounds.size.z;

       range_X = Random.Range((range_X / 2) * -1, range_X / 2);
       range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
       Vector3 bbasePosition = new Vector3(basePosition.x, -0.3922725f, basePosition.z);
       Vector3 RandomPostion = new Vector3(range_X, 0.0f, range_Z);

       Vector3 respawnPosition = bbasePosition + RandomPostion;

       return respawnPosition;
       
    }
   
    private void Spawn()
    {
        character = Resources.Load<GameObject>($"UI_pref/SpawnCharacter/{PlayerCharacter.ModelName}");
        //character = Resources.Load<GameObject>($"UI_pref/SpawnCharacter/woman_mechanic");
        Vector3 spawnPos = GetRandomPosition();

        contentscharacter = BoltNetwork.Instantiate(character, spawnPos, Quaternion.Euler(0, 0, 0));
        //contentscharacter = Instantiate(character, spawnPos, Quaternion.Euler(0, 0, 0));
        contentscharacter.transform.position = new Vector3(spawnPos.x, -0.3f, spawnPos.z);
        Debug.Log($"spwanPos: {spawnPos}");
        
    }



}
