using System;
using UnityEngine;
public class FrozzenEnemy : IEnemyToSpawn
{
     float maxDisntance;
     float currentDisntance;


     private void Start()
     {
         maxDisntance = 15;
     }

     private void Update()
     {
         currentDisntance += Time.deltaTime;
         if (currentDisntance >= maxDisntance)
         {
             ReturnToPool();   
         }
     }
     
    private void Reset()
    {
        currentDisntance = 0;
    }

    public override void ReturnToPool()
    {
        NewGenerator.instance._EnemysDict[NewGenerator.instance._levelManager.currentLevel.Order].ReturnObject(this);
    }

    public override void Init()
    {
        currentDisntance = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        ReturnToPool();
    }
}
