using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;
    public static ScoreManager Instance;

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

    public int Score { get; private set; } //Andere scripts kunnen bij Score komen en de amount omhoog zetten

    #region Function responsible for increasing score
    public void IncreaseScore(int amount)
    {
        Score += amount;
        text.text = "Score: " + Score;
    }
    #endregion
}
