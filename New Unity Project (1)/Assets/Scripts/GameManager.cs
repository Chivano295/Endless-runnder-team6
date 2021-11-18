using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ObjectPool pickupPool;
    [SerializeField] ObjectPool obstaclePool;
    [SerializeField] ObjectPool segmentPool;
    [SerializeField] Vector3[] segmentStartSpawn;
    [SerializeField] Vector3 segmentNextSpawn;

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

    private void Start()
    {
        //Spawns the first few segments
        for (int i = 0; i < segmentStartSpawn.Length; i++)
        {
            GameObject _segment = segmentPool.GetPooledObject(transform.position, Quaternion.identity);
            _segment.transform.position = segmentStartSpawn[i];
        }
    }

    //When called, spawns next segment at location
    public void NextSegment()
    {
        segmentPool.GetPooledObject(segmentNextSpawn, Quaternion.identity);

    }

    //Back in 2020, myself and David van Rijn worked on Endless Runner. Code similarties are likely!
}
