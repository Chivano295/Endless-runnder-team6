using UnityEngine;

public class Segment : PoolItem
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float removeLoc;

    private Renderer getRend;

    private void Start()
    {
        getRend = GetComponent<Renderer>();
    }

    //Moves the segment at given speed and check if it reaches a certain position
    private void Update()
    {
        float offset = Time.time * moveSpeed;
        getRend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));

        //Disabled due to alternate method
        //transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
        if (transform.position.z <= removeLoc)
        {
            GameManager.Instance.NextSegment();
            GameManager.Instance.RemoveSegment(this);
        }

    }

    //Back in 2020, myself and David van Rijn worked on Endless Runner. Code similarties are likely!
}
