using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : IUpgradeToSpawn
{
    float maxDistance;
    float currentDistance;
        // Start is called before the first frame update
    private void Reset()
    {
        currentDistance = 0;
    }
    void Start()
    {
        maxDistance = 15;
        
    }
    public static void TurnOn(CoinScript e){e.Reset(); e.gameObject.SetActive(true);}
    public static void TurnOff(CoinScript e){e.gameObject.SetActive(false);}

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
        NewGenerator.instance._UpgradeDict[NewGenerator.instance._levelManager.currentLevel.Order].ReturnObject(this);
    }

    public override void Init()
    {
        currentDistance = 0;
    }
}
