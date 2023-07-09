using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielUpg : IUpgradeToSpawn
{
   float maxDistance;
   float currentDistance;
   

   private void Reset()
   {
       currentDistance = 0;
   }
   void Start()
   {
     maxDistance = 15;
   }
   void Update()
   {
     currentDistance += Time.deltaTime;
     if (currentDistance >= maxDistance)
     {
        ReturnToPool();   
     }  
   }
   private void OnTriggerEnter(Collider other)
   {
       ReturnToPool();
   }
   public static void TurnOn(ShielUpg e){e.Reset(); e.gameObject.SetActive(true);}
   public static void TurnOff(ShielUpg e){e.gameObject.SetActive(false);}
   public override void ReturnToPool()
   {
      // Generator.instance.shieldPool.ReturnObject(this);
      NewGenerator.instance._UpgradeDict[NewGenerator.instance._levelManager.currentLevel.Order].ReturnObject(this);
   }

   public override void Init()
   {
       currentDistance = 0;
       
   }
}

