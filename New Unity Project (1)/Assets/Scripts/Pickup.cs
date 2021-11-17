using UnityEngine;

public class Pickup : PoolItem
{
    void Update()
    {
        //Thanks to Luke Armstrong's roll-a-ball tutorial
        //Makes the pickup rotate
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    //Checks for collision with player and boundary, returns to pool and increases score if applicable
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ReturnToPool();
            ScoreManager.Instance.IncreaseScore(10);
        }

        if (collision.gameObject.CompareTag("Boundary"))
        {
            ReturnToPool();
        }
    }
}
