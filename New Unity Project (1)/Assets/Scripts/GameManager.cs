using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ObjectPool pickupPool;
    [SerializeField] ObjectPool obstaclePool;

    public static GameManager Instance;

    #region Singleton in awake
    private void Awake()
    {
        if (Instance != null && Instance != this) //singleton
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion
}
