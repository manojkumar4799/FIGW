using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
