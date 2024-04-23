using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    public KitchenObjectSO inputObjectSO;
    public KitchenObjectSO outputObjectSO;
    public float fryingTimerMax;
}
