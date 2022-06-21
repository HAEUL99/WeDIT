using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScrollView : MonoBehaviour
{
    private int gameRoomnum;
    private GameObject roombtnPref;
    private GameObject roombtn;
    private Transform roombtnParent;

    private void Start()
    {
        //gameRoomnum = TotalsessionInfo.sessionNum;
        roombtnParent = gameObject.transform.GetChild(0).GetChild(0);
        LoadRoomButtons();
    }


    private void LoadRoomButtons()
    {
        for (int i = 0; i < gameRoomnum; i++)
        {
            roombtnPref = Resources.Load<GameObject>("UI_pref/RoomButton/Roombtn");
            roombtn = Instantiate(roombtnPref, roombtnParent);

        }
    }


}