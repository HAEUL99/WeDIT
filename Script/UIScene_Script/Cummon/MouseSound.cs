using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSound : MonoBehaviour
{

    private AudioSource mouseclick;

    // Start is called before the first frame update
    void Start()
    {
        mouseclick = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseclick.Play();
        }
    }
}
