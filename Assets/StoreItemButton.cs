using System;
using ScriptableObj;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemButton : MonoBehaviour
{
    private Text ItemText;

    [SerializeField] protected Lootbox Scriptable;

    private void Awake()
    {
        ItemText = gameObject.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        ItemText.text = Scriptable._itemName;
    }
}
