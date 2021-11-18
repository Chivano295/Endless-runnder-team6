using UnityEngine;

public class Segment : PoolItem
{
    [SerializeField] private float moveSpeed;

    //Moves the segment at given speed
    private void Update()
    {
        transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);

    }

    //Checks for collision with boundary, returns to pool and calls function for next segment
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            GameManager.Instance.NextSegment();
            GameManager.Instance.RemoveSegment(this);
        }
    }

    //Back in 2020, myself and David van Rijn worked on Endless Runner. Code similarties are likely!
}
