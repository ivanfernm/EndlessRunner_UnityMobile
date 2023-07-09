using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObj;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemCanvas : MonoBehaviour,Iscreen
{
    [Header("Manager")] 
    [SerializeField] protected StoreItemManager _manager;
    [SerializeField] protected SaveManager _saveManager;
    
    [Space (10)]
    [Header("ScriptableObject")]
    [SerializeField] protected Lootbox _scriptableObject;

    [Space(10)] [Header("Canvas Objects")]
    [SerializeField] protected Image _itemImage;
    [SerializeField] protected Text _itemName;
    [SerializeField] protected Text _itemDescription;
    [SerializeField] protected Text _itemPrice;
    protected int id = 0;
    
    private void Start()
    {
        if (!_scriptableObject)
        {
            return;
        }
    }

    private void Awake()
    {
        _manager = GameObject.FindObjectOfType<StoreItemManager>();
        _saveManager = SaveManager.instance;
    }

    public void ChargeScriptableObject()
    {
        _itemName.text = _scriptableObject._itemName;
        _itemImage.sprite = _scriptableObject._storeIcon;
        _itemImage.SetNativeSize();
        _itemDescription.text = _scriptableObject._itemDescription;
        _itemPrice.text = " " + _scriptableObject._itemPrice;
        id = _scriptableObject._id;
    }

    public void Activate()
    {
        _scriptableObject = _manager.Test;
        ChargeScriptableObject();
    }
    
    public void Deactivate()
    {
        
    }

    public void Free()
    {
        Destroy(gameObject);
    }

    public void BuyItem()
    {
        if (StaticVar.Currency >= _scriptableObject._itemPrice)
        {
            StaticVar.BoxIntentory.Add(_scriptableObject);
            StaticVar.Currency = StaticVar.Currency - _scriptableObject._itemPrice;
            _saveManager.Save();
            Debug.Log(StaticVar.BoxIntentory);
        }

    }
}
