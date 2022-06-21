using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStage3Spawn : MonoBehaviour
{
    public Stage2Respawn stage2respawn;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {

            stage2respawn.spawnPoint = 3;
        }
    }

}
