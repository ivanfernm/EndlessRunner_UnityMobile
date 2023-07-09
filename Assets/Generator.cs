using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{

    //tengo q crear un dictionario de pool
    
    int Random2;
    int Random3;
    public Vector3[] PointsToSpawn;
    float TimeToSpawn;
    public float Cooldown;
    public float waveEnds;
    public float timeWave;

    public static Generator instance;

    public LevelManager _LevelManager;

    //ObjectPool
    [SerializeField] protected List<IEnemyToSpawn> enemys;

    [SerializeField] protected List<IUpgradeToSpawn> _upgrades;

    // we need to set this up using linq when we filter the enum
    public ObjectPool<IEnemyToSpawn> _enemysPool;
    public ObjectPool<IUpgradeToSpawn> _upgradesPool;

    void Start()
    {

        _LevelManager = LevelManager.instance;
        UpdateEnemy();

        instance = this;


        #region PoolGeneration

            _enemysPool = new ObjectPool<IEnemyToSpawn>(EnemyReturn, IEnemyToSpawn.TurnOn, IEnemyToSpawn.TurnOff, 50);
            _upgradesPool =
            new ObjectPool<IUpgradeToSpawn>(UpgradeReturn, IUpgradeToSpawn.TurnOn, IUpgradeToSpawn.TurnOff, 50);

        #endregion

    }
    void Update()
    {
        UpdateEnemy();
        timeWave += Time.deltaTime;
        if (timeWave >= waveEnds)
        {
            if (Cooldown >= 0.5)
            {
              Cooldown = Cooldown * 0.8f;                   
            }
            else{}
            timeWave = 0;
        }
        TimeToSpawn += Time.deltaTime;
        if (TimeToSpawn >= Cooldown)
        {
            StartCoroutine("Spawn");           
            TimeToSpawn = 0;
        }  
    }

    public void UpdateEnemy()
    {
        enemys = _LevelManager._lvlSpawnEnemys;
         _upgrades = _LevelManager._lvlSpawnUpgrade;
    }
    
    IEnumerator Spawn()
    {
        
        //Debug.Log("Enemy has been spawn");
         int Random1 = Random.Range(0,3);

            switch (Random1)
            {
                case 0:
                    Random2 = 2;
                    Random3 = 1;
                    break;
                case 1:
                    Random3 = 2;
                    Random2 = 0;
                    break;
                case 2:
                    Random2 = 0;
                    Random3 = 1;
                     break;
                
            }
          
          #region Carril 1
           int generator1 = Random.Range(0,100);
           if (generator1 >10 & generator1 < 45)
           {
               var O = _enemysPool.GetObject();
               O.transform.position = PointsToSpawn[Random1];
           }
           else if (generator1 >45)
           {
               var O = _enemysPool.GetObject();
               O.transform.position = PointsToSpawn[Random1];
               
           }
           else
           {
               var O = _enemysPool.GetObject();
               O.transform.position = PointsToSpawn[Random1];
           }
           #endregion
           
           #region  carril 3
           int generator2 = Random.Range(0,100);
           if (generator2 >10 & generator2 < 45)
           {
               var I = _enemysPool.GetObject();
               I.transform.position = PointsToSpawn[Random3];
           }
           else if (generator2 >45)
           {
               var I = _enemysPool.GetObject();
               I.transform.position = PointsToSpawn[Random3];
               
           }
           else
           {
               var I = _enemysPool.GetObject();
               I.transform.position = PointsToSpawn[Random3];
               
           }
          
           #endregion
           //Aca iban las upgrades
           #region  Carril 2
            int generator3 = Random.Range(0,100);
            if (generator3 <20)
            {
                var U = _upgradesPool.GetObject();
                U.transform.position = PointsToSpawn[Random2];
            }
            else if (generator3 >20 & generator3 < 40)
            {
              var U = _upgradesPool.GetObject();
              U.transform.position = PointsToSpawn[Random2];  
            }
            else
            {
                var U = _upgradesPool.GetObject();
                U.transform.position = PointsToSpawn[Random2];
            }        
            #endregion
        yield return null;
    }

    // Update is called once per frame
    public IEnemyToSpawn EnemyReturn()
    {
        return Instantiate(enemys[Random.Range(0,enemys.Count)]);
    }

    public IUpgradeToSpawn UpgradeReturn()
    {
        return Instantiate(_upgrades[Random.Range(0, _upgrades.Count)]);
    }
}
