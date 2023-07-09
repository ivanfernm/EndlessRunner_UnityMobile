using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour,Iscreen
{
    public Button PlayAgain ;
    public Button MainMenu;
    public Button Store;
    
    public void PlayAgainButton()
    {
        
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Free();
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void ShopButon()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Store");
    }
    // Start is called before the first frame update
    public void Free()
    {
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        PlayAgain.interactable = true;
        MainMenu.interactable = true;
        Store.interactable = true;
    }

    public void Deactivate()
    {
        PlayAgain.interactable = false;
        MainMenu.interactable = false;
        Store.interactable = false;
    }
}
