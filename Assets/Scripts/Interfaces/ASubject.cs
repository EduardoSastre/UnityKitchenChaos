using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASubject : MonoBehaviour
{
    protected List<AObserver> observers = new List<AObserver>();

    public abstract void addObserver(AObserver observer);
    public abstract void removeObserver(AObserver observer);
    public abstract void notifyObservers();
}
