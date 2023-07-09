using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "BookPool", menuName = "LootbooxPool", order = 0)]
    public class LootBooxPool : ScriptableObject
    {
        public List<StoreItem> Loot;
        
    }
}