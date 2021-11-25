using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updown : MonoBehaviour
{
    public CurrentShip shipData;
    public void Up()
    {
        shipData.player = shipData.player + 1;
    }
    public void down()
    {
        shipData.player = shipData.player - 1;
    }
}
