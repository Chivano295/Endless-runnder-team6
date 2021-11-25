using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Pool Settings")]
    [SerializeField] ObjectPool pickupPool;
    [SerializeField] ObjectPool obstaclePool;
    [SerializeField] ObjectPool segmentPool;
    [SerializeField] Vector3[] segmentStartSpawn;

    [Header("Obstacle/Pickup Spawn Settings")]
    [SerializeField] Vector2 timeClamp;
    private float spawnTime;
    private float timer;

    //Courtesy of David van Rijn
    [Header("Difficulty Settings")]
    [SerializeField] float increaseWait; //Amount of time before difficulty increases
    [SerializeField] float difficultyIncreaseRate; //Amount of time to before difficulty increases
    [SerializeField] float difficultyObstacleRate; //The amount of which obstacle spawn increases
    [SerializeField] float increasingSpeed = 5f; //The amount of which speed increases

    public delegate void DifficultyEvent(float increase);
    public event DifficultyEvent difficultyEvent;

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
        timer = Random.Range(timeClamp.x, timeClamp.y);

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
        spawnTime += Time.deltaTime;
        if (spawnTime >= timer)
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
            spawnTime = 0;
            timer = Random.Range(timeClamp.x, timeClamp.y);
        }

        difficultyIncreaseRate += Time.deltaTime;
        if (difficultyIncreaseRate >= increaseWait)
        {
            difficultyIncreaseRate = 0f;
        }
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

    #region Handles increasing difficulty
    public void CallDifficultyIncrease(float amount)
    {
        difficultyEvent.Invoke(amount);
        increasingSpeed += amount;
    }
    #endregion
    //Back in 2020, myself and David van Rijn worked on Endless Runner. Code similarties are likely!
}
