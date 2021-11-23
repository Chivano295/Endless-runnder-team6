using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject Deathmenu;
    public static Deathscreen Instance;

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
    public void Pause()
    {
        Deathmenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ChangeScene(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
