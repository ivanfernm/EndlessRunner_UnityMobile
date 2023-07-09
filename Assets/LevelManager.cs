using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptableObj;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LevelManager : MonoBehaviour
{

   [Header("List Of Leveles")] 
   
   public List<SO_Level> LevelsOrder;

   public SO_Level currentLevel;
   
   public static LevelManager instance;
   
   [Header("Spawns")]
   public List<IEnemyToSpawn> _lvlSpawnEnemys;
   public List<IUpgradeToSpawn> _lvlSpawnUpgrade;

   private float duration;
   
   private void Awake()
   {
      instance = this;
      currentLevel = LevelsOrder.First();
   }

   private void Start()
   {
     // StartCoroutine(SkipLevel());
     
     SaveManager.instance.Load();
     
     EventManager.Subscribe(EventManager.EventType.ChangeLevel,ChangeLvl);

     _lvlSpawnEnemys = currentLevel.lvlSpawnEnemys;
     _lvlSpawnUpgrade = currentLevel.lvlSpawnUpgrade;
     duration = currentLevel.LevelDuration;
   }

   private void Update()
   {
      duration -= Time.deltaTime;
      if (duration <= 0 )
      {
        EventManager.TriggerEvent(EventManager.EventType.ChangeLevel);
      }

   }
   
   public void ChangeLvl(params object[] parameters)
   {
      currentLevel = LevelsOrder[currentLevel.Order + 1];
      
      _lvlSpawnEnemys = currentLevel.lvlSpawnEnemys;
      _lvlSpawnUpgrade = currentLevel.lvlSpawnUpgrade;
      duration = currentLevel.LevelDuration;
      Debug.Log("LevelChanged");
      
     // EventManager.Unsuscribe(EventManager.EventType.ChangeLevel,ChangeLvl);
   }
   //aca necesitamos tene -> una colleccion con los levels en el que estamos y en los que vamos a estar una forma de elegir el orden

   //create a collection of desired levels


}
