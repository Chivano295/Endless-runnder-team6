using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int playerSpeed = 2;
    [SerializeField] bool debugMode = false;

    private Rigidbody rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (debugMode)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                ScoreManager.Instance.IncreaseScore(10);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                StartCoroutine(PlayerHealth.Instance.FlashCo());
            }
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rBody.MovePosition(rBody.position + new Vector3(horizontal, vertical, 0f) * playerSpeed * Time.fixedDeltaTime);
    }
}
