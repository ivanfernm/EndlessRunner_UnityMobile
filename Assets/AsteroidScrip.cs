using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScrip : IEnemyToSpawn
{
    float maxDistance;
    float currentDistance;
    
    private LevelSelector _levelSelector;
    private void Start()
    {
        maxDistance = 15;
    }
    
    private void Reset()
    {
        currentDistance = 0;
    }
    
    // Update is called once per frame
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
        currentDistance = 0;
    }
}
