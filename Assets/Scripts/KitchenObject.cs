using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour 
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private AInteractable parentObject;

    public KitchenObjectSO GetKitchenObjectSO() { return kitchenObjectSO; }

    public  AInteractable getParentObject() { 
        return parentObject;
    }

    public static void Create( GameObject kitchenObjectPrefab, AInteractable parent ) {

        KitchenObject kitchenObject = Instantiate(kitchenObjectPrefab, parent.GetPickPoint() ).GetComponent<KitchenObject>();
        kitchenObject.transform.localPosition = Vector3.zero;

        parent.SetKitchenObject( kitchenObject );
    }

    public static void Destroy(GameObject kitchenObjectPrefab, AInteractable parent)
    {
        parent.clearKitchenObject();
        Destroy(kitchenObjectPrefab);
    }

    public static void ChangeParent( AInteractable originalParent, AInteractable newParent )
    {
        KitchenObject kitchenObject = originalParent.GetKitchenObject();

        if ( !CheckObject.isNullOrEmpty(kitchenObject) ) {

            kitchenObject.transform.SetParent(newParent.GetPickPoint(), false);
            kitchenObject.transform.localPosition = Vector3.zero;

            newParent.SetKitchenObject(kitchenObject);
            originalParent.clearKitchenObject();
        }
    }

    public bool IsThisPlateKitchenObject() {

        if (this is PlateKitchenObject) {
            return true;
        }

        return false;
    }

}
