
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    public void LoadCustomScene(string Scenelvl) 
    {
        SceneManager.LoadScene(Scenelvl);
    }

    public void QuitApp() 
    {
        Application.Quit();
        Debug.Log("Game Is Being Closed");
    }
    public void SetTime(float time)
    {
        Time.timeScale = time; 
    }
}
