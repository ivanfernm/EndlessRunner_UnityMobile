using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScrip : MonoBehaviour,Iobserver
{


    public Animator camAnim;
    public ISubject _thingToObserv;

    public void CamShake()
    {
        camAnim.SetTrigger("Shake");
    }
    private void Start()
    {
        _thingToObserv = FindObjectOfType<PlayerBasics>();
        if (_thingToObserv != null)
        {
            _thingToObserv.Subscribe(this);

        }
        else
        {
            Debug.Log(this.name +  " No se pudo subscribir");
        }
    }

    public void OnNotify(string ActionToMake)
    {
        if (ActionToMake == "GetHit")
        {
            CamShake();
        }
    }

}
