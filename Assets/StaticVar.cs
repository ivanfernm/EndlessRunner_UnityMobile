using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObj;
using UnityEngine;

public static class StaticVar 
{
    public static int Currency = 0;
    public static int Life = 3;
    public static bool CanMove = true;
    public static bool IsDestructable = true;
    //public static Dictionary<int, StoreItem> Inventory = new Dictionary<int, StoreItem>();
    public static List<Lootbox> BoxIntentory = new List<Lootbox>();
    public static List<StoreItem> ItemsInventory = new List<StoreItem>();
    public static int GatchaRolls;
}
