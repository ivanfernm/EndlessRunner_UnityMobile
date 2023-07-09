using System;
using UnityEngine.UI;
using UnityEngine;

public class RollItemCanvas : MonoBehaviour,Iscreen
{
    
    [SerializeField] protected SaveManager _saveManager;
    [Space(10)] [Header("Canvas Objects")]
    [SerializeField] protected Image _itemImage;
    [SerializeField] protected Text _itemName;
    [SerializeField] protected Button _useButton;
    [SerializeField] public StoreItem Item;
    [SerializeField] public inventoryItemCanvas parent;
    // Start is called before the first frame update

    public void ChargeScriptableObject()
    {
        _itemImage.sprite = Item._storeIcon;
        _itemName.text = Item._itemName;

    }

    private void Awake()
    {
        _saveManager = SaveManager.instance;
        _useButton = gameObject.GetComponentInChildren<Button>();
    }

    private void Start()
    {
}

    #region MyRegion

        public void Activate()
        {
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

    public void useitem()
    {
        InventoryMenuManager.instance.UseButton(parent);
        Free();
    }
}

