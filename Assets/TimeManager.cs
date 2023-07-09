using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour,ISubject
{
    List<Iobserver> observers = new List<Iobserver>();
    public void NotifyTo(string ActionToMake)
    {
        for (var i = 0; i < observers.Count; i++)
        {
            observers[i] .OnNotify(ActionToMake); 
        }
    }

    public void Subscribe(Iobserver ObserverName)
    {
        if (!observers.Contains(ObserverName))
        {
            observers.Add(ObserverName);
            
        }
    }

    public void Unsuscribe(Iobserver ObserverName)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
