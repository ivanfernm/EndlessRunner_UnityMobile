using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour, Iobserver
{
    public ISubject _ThingToObserv;
    public void OnNotify(string ActionToMake)
    {
        if (ActionToMake == "PlayerDied")
        {
            ScreenManager.instance.Push("LoseMenu");
            ScreenManager.instance.TurnOffMenuButton(); 
        }
        else if (ActionToMake == "Revive")
        {
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _ThingToObserv = FindObjectOfType<PlayerBasics>();
        if (_ThingToObserv != null )
        {
            _ThingToObserv.Subscribe(this);   
        }
        else
        {
            Debug.Log(this.name + "no se pudo subcribir");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
