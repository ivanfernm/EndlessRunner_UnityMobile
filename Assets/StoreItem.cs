using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "StoreItem", menuName = "StoreItem", order = 0)]
    
public class StoreItem : ScriptableObject
{ 
        [Header("Canvas Objects")]
        [SerializeField] public Sprite _storeIcon;
        [SerializeField] public string _itemName;
        [SerializeField] public int stars;

        [SerializeField] public ActionType _actionType;

}

public enum ActionType
{
        Hp,
        Hp3,
        Shield,
}
