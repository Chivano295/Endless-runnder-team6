using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skinselection : MonoBehaviour
{
    public Material[] currentPlayer = new Material[5];
    public GameObject player;
    public CurrentShip shopData;
    [SerializeField]private MeshRenderer materialselect;

    private void Start()
    {
       materialselect =  player.GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (shopData.player == 0)
        {
            materialselect.material = currentPlayer[0];
        }
        if (shopData.player == 1)
        {
            materialselect.material = currentPlayer[1];
        }
        if (shopData.player == 2)
        {
            materialselect.material = currentPlayer[2];
        }
    }
}
