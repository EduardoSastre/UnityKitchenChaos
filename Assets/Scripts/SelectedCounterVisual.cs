using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedCounterVisual : AVisualObserver
{
    private AInteractable counter;
    private bool shouldInteract;

    private void Start()
    {
        GameInput.getInstance().addObserver(this);
    }

    public void Show() {
        VisualBehaviour.PerformVisualInteraction(counter);
    }

    public void Hide()
    {
        VisualBehaviour.CancelVisualInteraction(counter);
    }

    public void setCounter( AInteractable counter ) { 
        this.counter = counter;
    }

    public void setShouldInteract( bool shouldInteract ) {
        this.shouldInteract = shouldInteract;
    }



    public override void Actualize( bool isInteractionPerformed)
    {
        if (!CheckObject.isNullOrEmpty(counter)) {
            
            if (isInteractionPerformed && shouldInteract)
            {
                Show();
            } else
            {
                Hide();
            }

        }
    }

}
