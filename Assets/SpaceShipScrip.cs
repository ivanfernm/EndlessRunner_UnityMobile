using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScrip : IEnemyToSpawn
{
    float maxDistance;
    float currentDistance;
    private void Reset()
    {
        currentDistance  = 0;
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
    

    public override void ReturnToPool()
    {
        NewGenerator.instance._EnemysDict[NewGenerator.instance._levelManager.currentLevel.Order].ReturnObject(this);
    }

    public override void Init()
    {
        currentDistance  = 0;
    }
}
