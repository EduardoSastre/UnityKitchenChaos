using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABaseCounter : AInteractable
{

    [SerializeField] protected KitchenObjectSO kitchenObjectSO;

    public void Start()
    {
        SetPickPoint();
        Player.GetInstance().OnCounterInteraction += ABaseCounter_OnCounterInteraction;
    }

    private void ABaseCounter_OnCounterInteraction(object sender, Player.OnCounterInteractionEventsArgs interactedObjects)
    {
        Interact(interactedObjects.counter, interactedObjects.player);
    }

    public virtual void Interact(ABaseCounter counterInteracted, Player player) {

        if (counterInteracted == this)
        {
            if (!this.hasKitchenObject() && player.hasKitchenObject())
            {
                KitchenObject.ChangeParent(player, this);
            }
            else if (this.hasKitchenObject() && !player.hasKitchenObject())
            {
                KitchenObject.ChangeParent(this, player);
            }
            else if (this.hasKitchenObject() && player.hasKitchenObject())
            {

                bool hasPlayerPlate = player.GetKitchenObject() is PlateKitchenObject;
                bool hasCounterPlate = this.kitchenObjectOnPickPoint is PlateKitchenObject;
                bool areBothPlates = hasPlayerPlate && hasCounterPlate;

                if (!areBothPlates && (hasPlayerPlate || hasCounterPlate))
                {

                    PlateKitchenObject plateKitchenObject;

                    if (hasCounterPlate)
                    {

                        plateKitchenObject = kitchenObjectOnPickPoint as PlateKitchenObject;
                        plateKitchenObject.TryAddKitchenObjectSO(player.GetKitchenObject(), player);
                    }
                    else if (hasPlayerPlate)
                    {

                        plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                        plateKitchenObject.TryAddKitchenObjectSO(kitchenObjectOnPickPoint, this);
                    }
                }

            }
        }

    }

    public virtual void InteractAlternate() { 
        //TODO: FUTURE IMPLEMENTATION
    }

}
