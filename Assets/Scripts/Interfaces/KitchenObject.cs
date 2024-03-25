using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour 
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;

    private AInteractable parentObject;

    public KitchenObjectSO GetKitchenObjectSO() { return kitchenObjectSO; }

    public  AInteractable getParentObject() { 
        return parentObject;
    }

    public static KitchenObject Create( GameObject prefab, Transform place ) {

        KitchenObject kitchenObject = Instantiate(prefab, place).GetComponent<KitchenObject>();
        kitchenObject.transform.localPosition = Vector3.zero;

        return kitchenObject;
    }

    public static void ChangeParent( KitchenObject kitchenObject, AInteractable originalParent, AInteractable newParent )
    {

        kitchenObject.transform.SetParent(newParent.GetPickPoint(), false);
        kitchenObject.transform.localPosition = Vector3.zero;
        
        newParent.SetKitchenObject(kitchenObject);
        originalParent.clearKitchenObject();
    }

}
