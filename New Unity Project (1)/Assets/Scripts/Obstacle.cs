using UnityEngine;

public class Obstacle : PoolItem
{
    //Checks for collisions between player and boundary, returns to pool and damages player if applicable
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ReturnToPool();

        }

        if (collision.gameObject.CompareTag("Boundary"))
        {
            ReturnToPool();
        }
    }
}
