using System.Collections.Generic;
using Interfaze;
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "Level Struct", menuName = "Level Struct", order = 0)]
    public class SO_Level : ScriptableObject
    {

        [Header("Data")] 
        
        public string LevelName;

        public float LevelDuration;

        public int Order;
        
        [Header("Spawn")]
       
        public List<IEnemyToSpawn> lvlSpawnEnemys;

        public List<IUpgradeToSpawn> lvlSpawnUpgrade;


    }
}