using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roombtn : MonoBehaviour
{
    [HideInInspector] public int levelIndex;
    [HideInInspector] public RoomScrollView roomScrollview;

    [SerializeField] private Text roombtntxt;

    // Start is called before the first frame update
    void Start()
    {
        roombtntxt.text = "level -" + (levelIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
