using UnityEngine;

public class Segment : PoolItem
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float removeLoc;

    //Moves the segment at given speed and check if it reaches a certain position
    private void Update()
    {
        transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);

        if (transform.position.z <= removeLoc)
        {
            GameManager.Instance.NextSegment();
            GameManager.Instance.RemoveSegment(this);
        }

    }

    //Back in 2020, myself and David van Rijn worked on Endless Runner. Code similarties are likely!
}
