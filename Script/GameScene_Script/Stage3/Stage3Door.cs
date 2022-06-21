//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Bolt;

//public class Stage3Door : Photon.Bolt.EntityEventListener<IStage3Mission>
//{
//    public override void Attached()
//    {
//        state.SetTransforms(state.Stage3Door, transform);

//        state.AddCallback("Stage3Door", Moving);
//    }

//    void Moving()
//    {

//        entity.transform.position = state.Stage3Door.Position;
//        entity.transform.rotation = state.Stage3Door.Rotation;

//    }
//}
