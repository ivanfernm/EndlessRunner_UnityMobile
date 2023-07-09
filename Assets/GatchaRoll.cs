using System.Linq;
using ScriptableObj;
using UnityEngine;

public class GatchaRoll
{
        private LootBooxPool _pool;
        public StoreItem _Price;
        
        public GatchaRoll(LootBooxPool pool)
        {
                _pool = pool;
                _Price = determinateProbabilitys(pool);
        }

        public StoreItem determinateProbabilitys(LootBooxPool pool)
        {
                var currentRolls = StaticVar.GatchaRolls;
                var currentList = pool.Loot.OrderBy(x => x.stars).ToList();
                StoreItem aObjectpool = currentList.First();
                //si el roll es mayor a 7 garantiza 5 estrellas
                if (currentRolls >= 7)
                {
                       var a= currentList.Where(x => x.stars == 5).ToList();
                       if (a.Count > 0)
                       {
                               var b = a[Random.Range(0, a.Count - 1)];
                               aObjectpool =  b;
                               
                       }
                }
                else
                {
                        var a = currentList[Random.Range(0,currentList.Count - 1)];
                        aObjectpool = a;
                }

                StaticVar.GatchaRolls++;

                return aObjectpool;
        }
}
