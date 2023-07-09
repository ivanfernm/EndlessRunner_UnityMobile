using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTranslatw : MonoBehaviour
{
    public string ID;
    public Text myText; 
    void Start()
    {
        LangManager.instance.OnUpdate += ChangeLang;
    }
    public void ChangeLang()
    {
        myText.text = LangManager.instance.GetTranslate(ID);
    }

}
