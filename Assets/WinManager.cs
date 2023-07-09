using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public float RoundTime;
    public float currentTime;
    public static WinManager instance;
    public GameObject WinMenu;

    bool playerWin;
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= RoundTime)
        {
            playerWin = true;
            currentTime = 0;
            Time.timeScale= 0 ;
        }
        if (playerWin)
        {
           WinMenu.SetActive(true);

        }
    }
}
