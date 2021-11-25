using UnityEngine;

public class StaticSegment : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Renderer getRend;

    private void Start()
    {
        getRend = GetComponent<Renderer>();
    }

    //Moves the texture of the segment
    private void Update()
    {
        float offset = Time.time * moveSpeed;
        getRend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}
