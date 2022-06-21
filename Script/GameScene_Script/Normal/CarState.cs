using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class CarState : Photon.Bolt.EntityBehaviour<ICarState>
{
    /*public override void Attached()
    {
        state.SetTransforms(state.CarTransform, transform);

        state.AddCallback("CarTransform", MovingStage);
    }

    void MovingStage()
    {

        entity.transform.position = state.CarTransform.Position;
        entity.transform.rotation = state.CarTransform.Rotation;

    }*/
}
