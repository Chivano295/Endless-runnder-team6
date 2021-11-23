using UnityEngine;

public class Obstacle : PoolItem
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float removeLoc;

    //Returns the obstacle to objectpool upon reaching a certain position
    private void Update()
    {
        transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);

        if (transform.position.z <= removeLoc)
        {
            ReturnToPool();
        }
    }

    //Checks for collisions between player and boundary, returns to pool and damages player if applicable
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance.DamagePlayer(1);
            PlayerHealth.Instance.StartRoutine();
            ReturnToPool();
        }
    }
}
