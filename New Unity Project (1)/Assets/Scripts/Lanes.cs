using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanes : MonoBehaviour
{
   
    float xPos;
    [SerializeField] private int LaneSwitch;
    private KeyCode testKey;

    void Start()
    {
        xPos = transform.position.x;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            LaneSwitch = LaneSwitch + 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            LaneSwitch = LaneSwitch - 1;
        }
        if (LaneSwitch <= 0)
        {
            LaneSwitch = 1;
        }
        if (LaneSwitch >= 4)
        {
            LaneSwitch = 3;
        }

       if(LaneSwitch == 2)
        {
            xPos.position.x = 15.71978;
        }
    }
}
