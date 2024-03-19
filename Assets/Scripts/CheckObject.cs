using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObject 
{
    public static bool isNullOrEmpty( GameObject gameObject ) {

        return gameObject == null || gameObject.name == null || gameObject.name == "";
    
    }

    public static bool isNullOrEmpty(AInteractable gameObject)
    {

        return gameObject == null || gameObject.name == null || gameObject.name == "";

    }

    public static bool isNullOrEmpty(KitchenObject gameObject)
    {

        return gameObject == null || gameObject.name == null || gameObject.name == "";

    }
}
