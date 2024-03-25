using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedCounterVisual : AVisualObserver
{
    private ABaseCounter counter;
    private bool shouldInteract;

    private void Start()
    {
        GameInput.getInstance().addObserver(this);
    }

    public void Show() {
        VisualCounterBehaviour.PerformVisualInteraction(counter);
    }

    public void Hide()
    {
        VisualCounterBehaviour.CancelVisualInteraction(counter);
    }

    public void setCounter( ABaseCounter counter ) { 
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
