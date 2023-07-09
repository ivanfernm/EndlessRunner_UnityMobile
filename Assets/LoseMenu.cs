using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoseMenu : MonoBehaviour,Iscreen, Iobserver
{
    public ISubject _thingToObserv;
    public Button WatchAdd;
    public Button MainMenu;

    public Button Reanude;

    private void Start()
    {
        _thingToObserv = FindObjectOfType<PlayerBasics>();
         if (_thingToObserv != null)
        {
            _thingToObserv.Subscribe(this);
        }
        else
        {
            Debug.Log(this.name + "  no  se puede subscribir");
        }
    }


    public void MainMenuButton(){Time.timeScale = 1; SceneManager.LoadScene("Menu");}
    public void WatchAddButton()
    {
        AdInitializer.instance.ShowAdds();  
    }
    public void Activate()
    {
        WatchAdd.interactable = true;
        MainMenu.interactable = true;
    }

    public void Deactivate()
    {
        WatchAdd.interactable = false;
        MainMenu.interactable = false;
    }

    public void Free()
    {
       Destroy(gameObject);
    }
    public void ReanudeButton()
    {
       Time.timeScale = 1;
       ScreenManager.instance.TurnOnMenuButton();
       AudioManager.instance.play("MainTheme");
       Free(); 
    }

    public void OnNotify(string ActionToMake)
    {
        if (ActionToMake == "Revive")
        {   
           Reanude.interactable = true;
        }
    }
}
