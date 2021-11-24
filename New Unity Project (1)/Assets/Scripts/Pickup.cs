using UnityEngine;

public class Pickup : PoolItem
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float removeLoc;
    [SerializeField] AudioClip audioPickup;

    void Update()
    {
        //Thanks to Luke Armstrong's roll-a-ball tutorial
        //Makes the pickup rotate and returns the obstacle to objectpool upon reaching a certain position
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);

        if (transform.position.z <= removeLoc)
        {
            ReturnToPool();
        }
    }

    //Checks for collision with player, returns to pool and increases score if applicable
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayClip(audioPickup);
            ScoreManager.Instance.IncreaseScore(10);
            ReturnToPool();
        }
    }
}
