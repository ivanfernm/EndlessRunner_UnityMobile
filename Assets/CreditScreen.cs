using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditScreen : MonoBehaviour, Iscreen
{
    public Button BackButton;
    public Iscreen PauseMenu;
    private void Start()
    {
        PauseMenu = FindObjectOfType<PauseScreen>();
    }


    public void Activate()
    {
        BackButton.interactable = true;
    }

    public void Deactivate()
    {
        BackButton.interactable = false;
    }

    public void Free()
    {
        Destroy(gameObject);
        PauseMenu.Activate();
        
    }


}
