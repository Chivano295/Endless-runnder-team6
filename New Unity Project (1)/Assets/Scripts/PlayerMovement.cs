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

    #region Debug mode in Update
    // Debug mode in Update
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
#endregion

    #region Player movement
    //Handles player movements
    private void FixedUpdate()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        Vector3 _newpos = rBody.position + new Vector3(_horizontal, _vertical, 0f) * playerSpeed * Time.fixedDeltaTime;
        _newpos.x = Mathf.Clamp(_newpos.x, -6f, 6f);
        rBody.MovePosition(_newpos);
        //Thanks Rene for the assist with the clamp
    }
    #endregion
}
