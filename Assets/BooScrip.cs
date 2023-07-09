using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooScrip : IEnemyToSpawn
{

    float maxDisntance;
    float currentDisntance;
    private LevelSelector _levelSelector;
    

    public override void ReturnToPool()
    {
        NewGenerator.instance._EnemysDict[NewGenerator.instance._levelManager.currentLevel.Order].ReturnObject(this);
    }

    public override void Init()
    {
        currentDisntance = 0;
    }

    void Reset() 
    {
        currentDisntance = 0;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        maxDisntance = 15;
    }

    // Update is called once per frame
    void Update()
    {
        currentDisntance += Time.deltaTime;
        if (currentDisntance >= maxDisntance)
        {
            ReturnToPool();   
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        ReturnToPool();
    }

}
