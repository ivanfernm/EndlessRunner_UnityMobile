using System.Collections;
using UnityEngine;

public abstract class IEnemyToSpawn : MonoBehaviour
{
    public abstract void ReturnToPool();

    public abstract void Init();
    public static void TurnOn(IEnemyToSpawn e)
    {
        //Este codigo de abajo me trolleo
        e.gameObject.SetActive(true);
    }

    public  static void TurnOff(IEnemyToSpawn e)
    {
        e.gameObject.SetActive(false);
    }

}
