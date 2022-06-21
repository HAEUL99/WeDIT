//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Bolt;

//public class Stage3Button2 : Photon.Bolt.EntityEventListener<IStage3Mission>
//{
//    public override void Attached()
//    {
//        state.SetTransforms(state.Stage3Button2, transform);

//        state.AddCallback("Stage3Button2", Moving);
//    }

//    void Moving()
//    {

//        entity.transform.position = state.Stage3Button2.Position;
//        entity.transform.rotation = state.Stage3Button2.Rotation;

//    }
//}
