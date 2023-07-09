using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject 
{
    void Subscribe(Iobserver ObserverName);
    void Unsuscribe(Iobserver ObserverName);
    void NotifyTo(string ActionToMake);

}
