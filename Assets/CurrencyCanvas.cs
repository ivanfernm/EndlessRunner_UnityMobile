using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyCanvas : MonoBehaviour, Iobserver
{
    public Text CoinText;
    public ISubject PlayerObserver;

    int CurrentMoney;
    private void Start()
    {
        CurrentMoney = StaticVar.Currency;
        CoinText.text = "" + CurrentMoney; 
        PlayerObserver = FindObjectOfType<PlayerBasics>();
        if (PlayerObserver != null)
        {
            PlayerObserver.Subscribe(this);
        }
        else
        {
           // Debug.Log(this.name + "  no  se puede subscribir");
        }
    }
    public void OnNotify(string ActionToMake)
    {
        if (ActionToMake == "GetCoin")
        {
            CurrentMoney = StaticVar.Currency;
            CoinText.text = "" + CurrentMoney;
        }
        else if (ActionToMake == "LooseCoins")
        {
            CurrentMoney = PlayerBasics.instance.currency;
            CoinText.text = "" + CurrentMoney; 
        }
    }
}
