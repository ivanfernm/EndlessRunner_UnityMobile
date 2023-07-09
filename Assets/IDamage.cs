using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamage : MonoBehaviour, Iobserver
{
    public ISubject _thingToObserv;
    private void Start()
    {
        _thingToObserv = FindObjectOfType<PlayerBasics>();
        if (_thingToObserv != null)
        {
            _thingToObserv.Subscribe(this);
        }
        else
        {
            Debug.Log(this.name + "  no  se puede subscribir");
        }
    }
    public void OnNotify(string ActionToMake)
    {
        if (ActionToMake == "GetHit")
        {
            Debug.Log("collision");

        }
    }
}
