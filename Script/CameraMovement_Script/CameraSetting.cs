using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class CameraSetting : Photon.Bolt.EntityBehaviour<IPlayerState>
{

    void Start()
    {
        if (entity.IsOwner)
        {
            gameObject.GetComponentInChildren<Camera>().enabled = true;
            gameObject.GetComponentInChildren<AudioListener>().enabled = true;
        }

        else
        {
            gameObject.GetComponentInChildren<Camera>().enabled = false;
            gameObject.GetComponentInChildren<AudioListener>().enabled = false;
        }

    }

}