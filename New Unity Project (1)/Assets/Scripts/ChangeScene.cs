using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject MainUI;
    public void ChangeScen(string scene)
    {
        
        SceneManager.LoadScene(scene);

    }
    public void Setactive()
    {
        ShopUI.SetActive(true);
        MainUI.SetActive(false);
    }
    public void SetDeActive()
    {
        ShopUI.SetActive(false);
        MainUI.SetActive(true);
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
