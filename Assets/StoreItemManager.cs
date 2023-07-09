using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObj;
using UnityEngine;

public class StoreItemManager : MonoBehaviour
{
    public static StoreItemManager _instance;
    public Lootbox Test;
    private Stack<Iscreen> ScreenList = new Stack<Iscreen>();

    private void Awake()
    {
        _instance = this;
    }

    protected void Push(Iscreen screen)
    {
        if (ScreenList.Count > 0)
        {
            ScreenList.Peek().Deactivate();
        }
        ScreenList.Push(screen);
        screen.Activate();
    }
    
    public void Push(string resource) 
    {
        var go = Instantiate(Resources.Load<GameObject>(resource));
        Push(go.GetComponent<Iscreen>());
    }

    public void ItemPush(Lootbox a)
    {
        Test = a;
        var go = Instantiate(Resources.Load<GameObject>("StoreItemCanvas"));
        Push(go.GetComponent<Iscreen>());
        
    }
    public void Pop() 
    {   
        if (ScreenList.Count < 1)
        {
            return;
        }
        ScreenList.Pop().Free();
        if (ScreenList.Count > 0)
        {
            ScreenList.Peek().Activate();
        }
    }

    public void Clear()
    {
        while (ScreenList.Count > 0)
        {
            ScreenList.Pop().Free();
        }
    }
    
}
