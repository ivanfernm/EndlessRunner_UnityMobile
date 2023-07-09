using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using ScriptableObj;

public class SaveManager : MonoBehaviour,Iobserver
{
    public static SaveManager instance;

    public ISubject _thingToObserv;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        
    }

    void Start()
    {
        _thingToObserv = FindObjectOfType<PlayerBasics>();
        if (_thingToObserv != null)
        {
            _thingToObserv.Subscribe(this);   
        }
        else
        {
            //Debug.Log(this.name + " No es pudo subscribir");
        }
        Load();
    }
   // Update is called once per frame
    public void Save()
    {
        SaveData saveData = new SaveData{
            goldAmount = StaticVar.Currency,
            boxInventor = StaticVar.BoxIntentory,
            itemsInventary = StaticVar.ItemsInventory,
        };

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
        Debug.Log("!SAVED");

    }
    public void Load()
    {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
             string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
             SaveData saveData = JsonUtility.FromJson<SaveData>(saveString);

             StaticVar.Currency = saveData.goldAmount;
             if (PlayerBasics.instance)
             {
                 PlayerBasics.instance.SetCurrency(StaticVar.Currency);
             }

             StaticVar.BoxIntentory = saveData.boxInventor;
             StaticVar.ItemsInventory = saveData.itemsInventary;

        }
        else
        {
            Debug.Log("There's no save");
        }

    }

    public void OnNotify(string ActionToMake)
    {
        if (ActionToMake == "PlayerDied")
        {
            Save();
        }
    }

    public class SaveData
    {
        public int goldAmount;
        public List<Lootbox> boxInventor;
        public List<StoreItem> itemsInventary;
    }

}
