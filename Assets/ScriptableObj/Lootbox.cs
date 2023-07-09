using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "Lootbox", menuName = "Lootbox", order = 0)]
    public class Lootbox : ScriptableObject
    {
        [SerializeField] public Sprite _storeIcon;
        [SerializeField] public int _id;
        [SerializeField] public string _itemName;
        [SerializeField] public string _itemDescription;
        [SerializeField] public int _itemPrice;

        [SerializeField] public LootBooxPool _lootBooxPool;
    }
}