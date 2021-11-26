using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Pool Settings")]
    [SerializeField] ObjectPool pickupPool;
    [SerializeField] ObjectPool obstaclePool;
    [SerializeField] ObjectPool segmentPool;
    [SerializeField] ObjectPool[] towerPools;
    [SerializeField] Vector3[] segmentStartSpawn;

    [Header("Obstacle/Pickup Spawn Settings")]
    [SerializeField] Vector2 timeClampObstacle; //Clamps time for obstacle and pickup spawn
    [SerializeField] Vector2 timeClampTower; //Clamps time for tower spawn
    private float obstacleSpawnTime; //obstacle and pickup spawn time
    private float towerSpawnTime; //tower spawn time
    private float primaryTimer;
    private float secondaryTimer;

    [Header("Difficulty Settings")]
    [SerializeField] public float globalMoveSpeed;
    [SerializeField] public float globalSegmentSpeed;
    [SerializeField] public float globalSpeedIncrease;
    [SerializeField] public float globalSegmentIncrease;

    private Transform lastSegment;
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
        //Randomizes time between two points
        primaryTimer = Random.Range(timeClampObstacle.x, timeClampObstacle.y);
        secondaryTimer = Random.Range(timeClampTower.x, timeClampTower.y);

        //Spawns the first few segments
        for (int i = 0; i < segmentStartSpawn.Length; i++)
        {
            GameObject _segment = segmentPool.GetPooledObject(transform.position, Quaternion.identity);
            _segment.transform.position = segmentStartSpawn[i];

            lastSegment = _segment.transform;
        }
    }

    //Handles obstacle and pickup spawning
    private void Update()
    {
        obstacleSpawnTime += Time.deltaTime;
        towerSpawnTime += Time.deltaTime;

        //Spawns obstacles and pickups
        if (obstacleSpawnTime >= primaryTimer)
        {
            float _randomNumber = Random.Range(1, 11); //randomizes whether obstacle or pickup spawns
            if (_randomNumber <= 8)
            {
                GameObject _obstacle = obstaclePool.GetPooledObject(transform.position, Quaternion.identity);
                _obstacle.transform.position = new Vector3(Random.Range(-6f, 6f), 1f, 25f);
            }
            else
            {
                GameObject _pickup = pickupPool.GetPooledObject(transform.position, Quaternion.identity);
                _pickup.transform.position = new Vector3(Random.Range(-6f, 6f), 1.5f, 25f);
            }
            obstacleSpawnTime = 0;
            primaryTimer = Random.Range(timeClampObstacle.x, timeClampObstacle.y);
        }

        //Spawns towers
        if (towerSpawnTime >= secondaryTimer)
        {
            RandomTower(towerPools[Random.Range(0, towerPools.Length)]);

            towerSpawnTime = 0;
            secondaryTimer = Random.Range(timeClampTower.x, timeClampTower.y);
        }
    }

    private void RandomTower(ObjectPool _pool)
    {
        GameObject _towerLeft = _pool.GetPooledObject(transform.position, Quaternion.identity);
        _towerLeft.transform.position = new Vector3(Random.Range(-25f, -10.5f), 0.65f, 40f);

        GameObject _towerRight = _pool.GetPooledObject(transform.position, Quaternion.identity);
        _towerRight.transform.position = new Vector3(Random.Range(25f, 10.5f), 0.65f, 40f);
    }

    #region segment spawn/despawn
    //When called, spawns next segment at location
    public void NextSegment()
    {
        Vector3 _spawnPos = lastSegment.position + Vector3.forward * 15f; //fix hardcode if necessary
        GameObject _segment = segmentPool.GetPooledObject(_spawnPos, Quaternion.identity);
        lastSegment = _segment.transform;
    }

    //When called, returns segment
    public void RemoveSegment(PoolItem _poolitem)
    {
        _poolitem.ReturnToPool();
    }
    #endregion
    //Back in 2020, myself and David van Rijn worked on Endless Runner. Code similarties are likely!
}
