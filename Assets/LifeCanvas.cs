using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCanvas : MonoBehaviour,Iobserver
{
    public Text lifeText;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;

    public int life;

    public ISubject PlayerObserver;
    
    private void Awake()
    {
    }
    private void Start()
    {
        PlayerObserver = FindObjectOfType<PlayerBasics>();
        life = PlayerBasics.instance.life;
        lifeText.text = "" + life;
        
        if (PlayerObserver != null)
        {
            PlayerObserver.Subscribe(this);
        }
        else
        {
            Debug.Log(this.name + "  no  se puede subscribir");
        }
    }
    public void OnNotify(string ActionToMake)
    {
        if (ActionToMake == "GetHit")
        {
            life = PlayerBasics.instance.life;
            looseLife();
           lifeText.text = "" + life; 
        }
        if (ActionToMake == "Revive")
        {
            life = PlayerBasics.instance.life;
            looseLife();   
            lifeText.text = "" + life;
        }
        if (ActionToMake == "GetLife")
        {
            life = PlayerBasics.instance.life;
            lifeText.text = "" + life;
            looseLife();
        }
    }
    public void looseLife() 
    {
        switch (life)
        {
            case 1:
                Life1.SetActive(true);
                Life2.SetActive(false);
                Life3.SetActive(false);
                break;
            case 2:
                Life1.SetActive(true);
                Life2.SetActive(true);
                Life3.SetActive(false);
                break;
            case 3:
                Life1.SetActive(true);
                Life2.SetActive(true);
                Life3.SetActive(true);
                break;
            case  0:
                Life1.SetActive(false);
                Life2.SetActive(false);
                Life3.SetActive(false);
                break;
        }
    }
}
