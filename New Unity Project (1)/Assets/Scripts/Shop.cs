using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
   
    public GameObject[] Currentshowing = new GameObject[3];
    public CurrentShip shipData;

    public void Update()
    {
       if(shipData.player == 0)
        {
            Currentshowing[0].SetActive(true);
            Currentshowing[1].SetActive(false);
            Currentshowing[2].SetActive(false);
        }
        if (shipData.player == 1)
        {
            Currentshowing[0].SetActive(false);
            Currentshowing[1].SetActive(true);
            Currentshowing[2].SetActive(false);
        }
        if (shipData.player == 2)
        {
            Currentshowing[0].SetActive(false);
            Currentshowing[1].SetActive(false);
            Currentshowing[2].SetActive(true);
        }
        if(shipData.player >= 3)
        {
            shipData.player = 0;
        }
        if (shipData.player <= -1)
        {
            shipData.player = 2;
        }
    }
}
