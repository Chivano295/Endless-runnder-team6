using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startHP = 3;
    [SerializeField] int maxHP = 3;
    [SerializeField] HeartManager heartManager;

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
        }
    }
}
