
using System;
using ScriptableObj;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class InventoryItem
{
    public GameObject go;
    private RectTransform _rectTransform = new RectTransform();
    public string name;
    public int id;
    public int index;
    public Lootbox st;
    
    public InventoryItem(Lootbox storeItem,int indexer)
    {
        name = storeItem._itemName;
        id = storeItem._id;
        index = indexer;
        st = storeItem;
        init();

    }

     void init()
    {
        go = new GameObject();
        go.AddComponent<RectTransform>();
        go.AddComponent<CanvasRenderer>();
        go.AddComponent<Image>();
        go.AddComponent<Button>();
    }

     public void setComponents(Lootbox a,GameObject parent)
     {
         go.name = a._itemName;
         go.transform.SetParent(parent.transform);
         var i =  go.GetComponent<Image>();
         var rt = go.GetComponent<RectTransform>();
         i.sprite = a._storeIcon;
         var but = go.GetComponent<Button>();
         but.onClick.AddListener(delegate { InventoryMenuManager.instance._Push(this); });
     }
}
