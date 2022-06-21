//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Bolt;

//public class Stage4Door : Photon.Bolt.EntityBehaviour<IStage4Mission>
//{
//    public override void Attached()
//    {
//        state.SetTransforms(state.Stage4Door, transform);

//        state.AddCallback("Stage4Door", MovingStage);
//    }

//    void MovingStage()
//    {

//        entity.transform.position = state.Stage4Tractor.Position;
//        entity.transform.rotation = state.Stage4Tractor.Rotation;

//    }
//}
