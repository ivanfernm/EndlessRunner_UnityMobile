using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUpgrade : IUpgradeToSpawn
{
    float maxDistance;
    float currentDistance;
    
    private void Reset()
    {
        currentDistance = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxDistance = 15;
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
       // Generator.instance.lifePool.ReturnObject(this);
       NewGenerator.instance._UpgradeDict[NewGenerator.instance._levelManager.currentLevel.Order].ReturnObject(this);
    }

    public override void Init()
    {
        currentDistance = 0;
    }
}
