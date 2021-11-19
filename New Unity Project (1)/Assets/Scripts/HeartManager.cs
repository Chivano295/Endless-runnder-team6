using UnityEngine;

public class HeartManager : MonoBehaviour
{
    [SerializeField] GameObject hpFull;
    [SerializeField] GameObject hpBroken;

    public void DrawHitpoint(int _hp, int _maxhp)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < _maxhp; i++)
        {
            if (i + 1 <= _hp)
            {
                GameObject _hitpoint = Instantiate(hpFull, transform.position, Quaternion.identity);
                _hitpoint.transform.parent = transform;
            }
            else
            {
                GameObject _hitpoint = Instantiate(hpBroken, transform.position, Quaternion.identity);
                _hitpoint.transform.parent = transform;
            }
        }
    }
    //Adapted from Muddy Wolf Dynamic Heart System tutorial on YouTube
}
