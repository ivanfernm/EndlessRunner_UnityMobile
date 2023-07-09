using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewGenerator : MonoBehaviour
{
    [Header("Reels")]
    int Random2;
    int Random3;
    public Vector3[] PointsToSpawn;
    public List<rail> railList;

    [Header("Timers")]
    float TimeToSpawn;
    public float Cooldown;
    public float waveEnds;
    public float timeWave;
    
    public LevelManager _levelManager;
    public static NewGenerator instance;

    public List<IEnemyToSpawn> _enemys;
    public List<IUpgradeToSpawn> _upgrades;

    private float _levelDuration;
    
    public ObjectPool<IEnemyToSpawn> _enemysPool;
    public ObjectPool<IUpgradeToSpawn> _upgradesPool;
    
    //create a dictionary of Objectpool
    public Dictionary<int, ObjectPool<IEnemyToSpawn>> _EnemysDict = new Dictionary<int, ObjectPool<IEnemyToSpawn>>();
    public Dictionary<int, ObjectPool<IUpgradeToSpawn>> _UpgradeDict = new Dictionary<int, ObjectPool<IUpgradeToSpawn>>();


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _levelManager = LevelManager.instance;
        
        GetFromLvlManager();
        CreatePool();
        EventManager.Subscribe(EventManager.EventType.ChangeLevel,TChangeLvl);
    }

    private void Update()
    {
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


    public void GetFromLvlManager()
    {
        _enemys = _levelManager.currentLevel.lvlSpawnEnemys;
        _upgrades = _levelManager.currentLevel.lvlSpawnUpgrade;
        _levelDuration = _levelManager.currentLevel.LevelDuration;
    }
    
    //temporaly changelvl method later change for eventManager
    public void TChangeLvl(params object[] parameters)
    {
        GetFromLvlManager();
        CreatePool();
    }

    void CreatePool()
    {
        var enemysPool = new ObjectPool<IEnemyToSpawn>(EnemyReturn, IEnemyToSpawn.TurnOn, IEnemyToSpawn.TurnOff,30);
        var updatePool = new ObjectPool<IUpgradeToSpawn>(UpgradeReturn, IUpgradeToSpawn.TurnOn, IUpgradeToSpawn.TurnOff,30);

        if (!_EnemysDict.ContainsKey(_levelManager.currentLevel.Order))
        {
            _EnemysDict.Add(_levelManager.currentLevel.Order, enemysPool);
            _UpgradeDict.Add(_levelManager.currentLevel.Order, updatePool);
        }
        
    }
    
    IEnumerator Spawn()
    {
        var railleft = railList[0];
        var railMiddle = railList[1];
        var railRight = railList[2];

        #region Rail::1

            if (Random.Range(0,100) >= 30)
            {
                var e = _EnemysDict[_levelManager.currentLevel.Order].GetObject();
                e.Init();
                e.transform.position = railMiddle.transform.position;
                railMiddle.CurrentSpanw = e.gameObject;
            }
            else
            {
                var e = _UpgradeDict[_levelManager.currentLevel.Order].GetObject();
                e.Init();
                e.transform.position = railMiddle.transform.position;
                railMiddle.CurrentSpanw = e.gameObject;
            }
        #endregion

        #region rail::2
        
            if (railRight._left.CurrentSpanw.TryGetComponent<IUpgradeToSpawn>(out IUpgradeToSpawn upgradeToSpaw))
            {
                var e = _EnemysDict[_levelManager.currentLevel.Order].GetObject();
                e.Init();
                e.transform.position = railRight.transform.position;
                railRight.CurrentSpanw = e.gameObject;
            }
            else
            {
                var e = _UpgradeDict[_levelManager.currentLevel.Order].GetObject();
                e.Init();
                e.transform.position = railRight.transform.position;
                railRight.CurrentSpanw = e.gameObject;
            }
        

        #endregion

        #region rail::3
            
            if (railleft._left.CurrentSpanw.TryGetComponent<IUpgradeToSpawn>(out IUpgradeToSpawn upgradeToSpawn)) 
            {
                var e = _EnemysDict[_levelManager.currentLevel.Order].GetObject();
                e.Init();
                e.transform.position = railleft.transform.position;
                railleft.CurrentSpanw = e.gameObject;
            }
            else
            {
                var e = _UpgradeDict[_levelManager.currentLevel.Order].GetObject();
                e.Init();
                e.transform.position = railleft.transform.position;
                railleft.CurrentSpanw = e.gameObject;
            }
        

        #endregion
        yield return new WaitForSeconds(.1f);
    }

    
    public IEnemyToSpawn EnemyReturn()
    {
        return Instantiate(_enemys[Random.Range(0,_enemys.Count)]);
    }

    public IUpgradeToSpawn UpgradeReturn()
    {
        return Instantiate(_upgrades[Random.Range(0, _upgrades.Count)]);
    }
}

