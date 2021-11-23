using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject Deathmenu;
    public bool death = false;


    private void Update()
    {
        if(death == true)
        {
            Pause();
        }                             
    }
    void Pause()
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
