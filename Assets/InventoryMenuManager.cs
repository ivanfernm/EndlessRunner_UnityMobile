using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObj;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryMenuManager : MonoBehaviour
{
   private VerticalLayoutGroup _verticalLayoutGroup;

   public static InventoryMenuManager instance;
   public GameObject content;
   public List<InventoryItem> _InventoryItems = new List<InventoryItem>();
   private UnityAction buttonAction;
   public int count = 0;

   
   private Stack<Iscreen> ScreenList = new Stack<Iscreen>();
   private void Awake()
   {
      instance = this;
      _verticalLayoutGroup = gameObject.GetComponentInChildren<VerticalLayoutGroup>();
   }

   private void Start()
   {
      SetItems();
   }
   void SetItems()
   {
      _InventoryItems = new List<InventoryItem>();
      foreach (var item in StaticVar.BoxIntentory)
      {
         var a = new InventoryItem(item,count);
         count++;
         a.setComponents(item,content);
         _InventoryItems.Add(a);
      }
      
      count = 0;

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

   public void ResourcePush(string resource)
   {
      var go = Instantiate(Resources.Load<GameObject>(resource));
      Push(go.GetComponent<Iscreen>());
   }
   
   public void RollitemMenu(string resource,StoreItem a,inventoryItemCanvas parent)
   {
      var go = Instantiate(Resources.Load<GameObject>(resource));
      var r =go.GetComponent<RollItemCanvas>();
      r.Item = a;
      r.parent = parent;
      Push(go.GetComponent<Iscreen>());
   }
   
   public void _Push(InventoryItem inventoryItem)
   {
      var go = Instantiate(Resources.Load<GameObject>("InventoryItemCanvas"));
      var x = go.GetComponent<inventoryItemCanvas>();
      x._parent = inventoryItem;
      Push(go.GetComponent<Iscreen>());
      
   }
   
   public void UseButton(inventoryItemCanvas screen)
   {
      StaticVar.BoxIntentory.Remove(screen._scriptableObject);
      SaveManager.instance.Save();
      Destroy(screen.gameObject);

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
