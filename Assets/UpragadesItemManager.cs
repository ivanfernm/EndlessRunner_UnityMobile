using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpragadesItemManager : MonoBehaviour
{
   private void Start()
   {
      if (StaticVar.ItemsInventory.Count >= 0)
      {
         CheckItems();
      }
   }

   public void CheckItems()
   {
      var itemInventory = StaticVar.ItemsInventory;

      foreach (var sItem in itemInventory)
      {
         switch (sItem._actionType)
         {
            case ActionType.Hp:
               PlayerBasics.instance.AddToLife(1);
               break;
            case ActionType.Hp3:
               PlayerBasics.instance.AddToLife(3);
               break;
            case ActionType.Shield:
               PlayerBasics.instance.ShieldState(true);
               break;
         }

         
      }

      StaticVar.ItemsInventory = new List<StoreItem>();
   }
}
