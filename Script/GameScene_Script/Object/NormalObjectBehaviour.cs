using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class NormalObjectBehaviour : Photon.Bolt.EntityBehaviour<INormalObjectState>
{
    

    public override void Attached()
    {
        state.SetTransforms(state.NormalObjectTransform, transform);

        state.AddCallback("NormalObjectTransform", Moveobject);

    }


    void Moveobject()
    {

        entity.transform.position = state.NormalObjectTransform.Position;
        entity.transform.rotation = state.NormalObjectTransform.Rotation;
    }


}
