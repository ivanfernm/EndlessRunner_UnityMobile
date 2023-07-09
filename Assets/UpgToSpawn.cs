using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgToSpawn : MonoBehaviour
{
    float maxDistance;
    float curretDistance;
    private void Start()
    {
        maxDistance = 15;
    }
    private void Reset()
    {
        curretDistance = 0;   
    }
    private void Update()
    {
        curretDistance += Time.deltaTime;
        if (curretDistance >= maxDistance)
        {
        }
    }
    public static void TurnOn(UpgToSpawn O) { O.Reset(); O.gameObject.SetActive(true);}
    public static void TurnOf(UpgToSpawn O) { O.gameObject.SetActive(false);}

    private void OnTriggerEnter(Collider other)
    {
    }
}
