using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour,Iscreen,ISubject
{
    public List<Iobserver> observers = new List<Iobserver>();
    public Button reanudeButton;
    public Button creditButton;
    public Button MainMenuButton;
    

    bool active;
    private void Awake()
    {
        NotifyTo("PauseMenuON");
    }


    public void Reanude()
    {
        Time.timeScale = 1;
        Free();
        
    }

    public void Credits() 
    {
        ScreenManager.instance.Push("CreditsMenu");
    }
    
    public void MainMenu(string MainMenuSceneName) 
    {
        ScreenManager.instance.TurnOnMenuButton();
        Time.timeScale = 1;
        SceneManager.LoadScene(MainMenuSceneName);
        
    }
    
    
    public void Activate()
    {
        reanudeButton.interactable = true;
        creditButton.interactable = true;
        MainMenuButton.interactable = true;
    }

    public void Deactivate()
    {
        reanudeButton.interactable = false;
        creditButton.interactable = false;
        MainMenuButton.interactable = false;
    }

    public void Free()
    {
        Destroy(gameObject);
        NotifyTo("PauseMenuOff");
    }

    public void Subscribe(Iobserver ObserverName)
    {
        if (!observers.Contains(ObserverName))
        {
            observers.Add(ObserverName);   
        }
    }

    public void Unsuscribe(Iobserver ObserverName)
    {
       if (observers.Contains(ObserverName))
       {
            observers.Remove(ObserverName);   
       }
    }

    public void NotifyTo(string ActionToMake)
    {
        for (var i = 0; i < observers.Count; i++)
        {
            observers[i].OnNotify(ActionToMake);   
        }
    }
    private void OnDestroy()
    {
        ScreenManager.instance.TurnOnMenuButton();
    }
    
    public void SaveDat(){ SaveManager.instance.Save();}
}
