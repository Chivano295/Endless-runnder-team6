using UnityEngine;

public class Tower : PoolItem
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float removeLoc;

    //Returns the tower to objectpool upon reaching a certain position
    private void Update()
    {
        transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);

        if (transform.position.z <= removeLoc)
        {
            ReturnToPool();
        }
    }
}
