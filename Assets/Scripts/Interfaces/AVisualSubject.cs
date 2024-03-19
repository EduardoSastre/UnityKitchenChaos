using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AVisualSubject : MonoBehaviour
{
    protected List<AVisualObserver> observers = new List<AVisualObserver>();

    public abstract void addObserver(AVisualObserver observer);
    public abstract void removeObserver(AVisualObserver observer);
    public abstract void notifyObservers(bool isInteractionPerformed);
}
