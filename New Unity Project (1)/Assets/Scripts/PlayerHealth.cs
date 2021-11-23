using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] int startHP = 3;
    [SerializeField] int maxHP = 3;
    [SerializeField] HeartManager heartManager;

    [Header("IFrame Settings")]
    [SerializeField] int flashNum;
    [SerializeField] float flashDur;
    [SerializeField] Color flashColour;
    [SerializeField] Color regColour;
    [SerializeField] CapsuleCollider playerCollider;
    [SerializeField] Renderer playerRend;

    public static PlayerHealth Instance;

    #region Singleton in awake

    private void Awake()
    {
        if (Instance != null && Instance != this) //singleton
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    private void Start()
    {
        heartManager.DrawHitpoint(startHP, maxHP);
    }

    public void DamagePlayer(int _dmg)
    {
        if (startHP > 0)
        {
            startHP -= _dmg;
            heartManager.DrawHitpoint(startHP, maxHP);
            //invincible and flickering
            DeadPlayer();
        }
    }

    private void DeadPlayer()
    {
        if (startHP <= 0)
        {
            Deathscreen.Instance.Pause();
        }
    }
    //Adapted from Muddy Wolf Dynamic Heart System tutorial on YouTube

    public IEnumerator FlashCo()
    {
        int _temp = 0;
        playerCollider.enabled = false;
        while (_temp < flashNum)
        {
            playerRend.material.color = flashColour;
            yield return new WaitForSeconds(flashDur);
            playerRend.material.color = regColour;
            yield return new WaitForSeconds(flashDur);
            _temp++;
        }
        playerCollider.enabled = true;
    }
     public void StartRoutine()
    {
        StartCoroutine(FlashCo());
    }
    //Adapted from Mister Taft Creates Invulnerability Frames tutorial on YouTube
}
