using System.Collections;
using System.Collections.Generic;
using ScriptableObj;
using UnityEngine;
using UnityEngine.UI;
public class inventoryItemCanvas : MonoBehaviour,Iscreen
{
    [Header("Manager")] 
    [SerializeField] public InventoryItem _parent;
    [SerializeField] protected SaveManager _saveManager;
    
    [Space(10)] [Header("Canvas Objects")]
    [SerializeField] protected Image _itemImage;
    [SerializeField] protected Text _itemName;

    [Space (10)]
    [Header("ScriptableObject")]
    [SerializeField] public Lootbox _scriptableObject;
    private void Awake()
    {
        _saveManager = SaveManager.instance;
    }

    #region Screen

        public void Activate()
        {
            _scriptableObject = _parent.st;
            ChargeScriptableObject();
        }

        public void Deactivate()
        {
        }

        public void Free()
        {
            Destroy(gameObject);
        }
    

    #endregion
    
    public void ChargeScriptableObject()
    {
        _itemImage.sprite = _scriptableObject._storeIcon;
        _itemName.text = _scriptableObject._itemName;

    }

    public void RollItem()
    {
        var roll = new GatchaRoll(_scriptableObject._lootBooxPool);
        var rollPrice = roll._Price;
        StaticVar.ItemsInventory.Add(rollPrice);
        InventoryMenuManager.instance.RollitemMenu("RolledItemCanvas",rollPrice,this);
    }
}
