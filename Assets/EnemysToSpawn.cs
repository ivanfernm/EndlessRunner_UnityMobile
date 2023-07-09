using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysToSpawn : MonoBehaviour , Iobserver
{
    public ISubject _thingToObserv;
    float maxDistance;
    float currentDistance;
    private void Reset()
    {
        currentDistance = 0;
    }
    private void Start()
    {
        _thingToObserv = FindObjectOfType<PlayerBasics>();
        if (_thingToObserv != null)
        {
            _thingToObserv.Subscribe(this);   
        }
        else{ Debug.Log(this.name + " No se pudo subscribir");}
        maxDistance = 15;
    }
    private void Update()
    {
        currentDistance += Time.deltaTime;
        if (currentDistance >= maxDistance)
        {
            //Generator.instance.EnemyToSpawnPool.ReturnObject(this);
        }
    }
    public static void TurnOn(EnemysToSpawn e) { e.Reset(); e.gameObject.SetActive(true); }
    public static void TurnOf(EnemysToSpawn e) { e.gameObject.SetActive(false);}

    public void OnNotify(string ActionToMake)
    {    
    }
    private void OnTriggerEnter(Collider other)
    {
        //Generator.instance.EnemyToSpawnPool.ReturnObject(this);  
        
    }
}
