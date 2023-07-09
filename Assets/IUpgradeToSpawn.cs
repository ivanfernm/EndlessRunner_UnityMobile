using UnityEngine;
public abstract class IUpgradeToSpawn : MonoBehaviour
{
        public abstract void ReturnToPool();

        public abstract void Init();
       
        public static void TurnOn(IUpgradeToSpawn e)
        {
                //Este codigo de abajo me trolleo
                e.gameObject.SetActive(true);
        }

        public  static void TurnOff(IUpgradeToSpawn e)
        {
                e.gameObject.SetActive(false);
        }
}
