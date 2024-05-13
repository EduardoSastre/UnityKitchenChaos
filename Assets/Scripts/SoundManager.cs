using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipsRefSO audioClipsRefSO;

    private static SoundManager soundManager;

    private void Awake()
    {
        soundManager = this;
    }

    private void Start()
    {
        DeliveryManager.GetInstance().OnRecipeSuccess += DeliveryCounter_OnRecipeSuccess;
        DeliveryManager.GetInstance().OnRecipeFailed += DeliveryCounter_OnRecipeFailed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        Player.GetInstance().OnPickedSomething += Player_OnPickedSomething;
        ABaseCounter.OnAnyObjectPlacedHere += ABaseCounter_OnAnyObjectPlacedHere;
        TrashCounter.OnDestroying += TrashCounter_OnDestroying;
    }

    private void TrashCounter_OnDestroying(object sender, System.EventArgs e)
    {
        TrashCounter trashCounter = (TrashCounter)sender;
        PlaySound(audioClipsRefSO.trash, trashCounter.transform.position);
    }

    private void ABaseCounter_OnAnyObjectPlacedHere(object sender, System.EventArgs e)
    {
        ABaseCounter baseCounter = (ABaseCounter)sender;
        PlaySound(audioClipsRefSO.objectDrop, baseCounter.transform.position );
    }

    private void Player_OnPickedSomething(object sender, System.EventArgs e)
    {
        Player player = sender as Player;
        PlaySound( audioClipsRefSO.objectPickUp, player.transform.position );
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound( audioClipsRefSO.chop, cuttingCounter.transform.position );
    }

    private void DeliveryCounter_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsRefSO.deliverySuccess, DeliveryCounter.GetInstance().transform.position );
    }

    private void DeliveryCounter_OnRecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsRefSO.deliveryFail, DeliveryCounter.GetInstance().transform.position);
    }

    private void PlaySound( AudioClip audioClip, Vector3 position, float volume ) {

        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 5f)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[Random.Range(0, audioClipArray.Length)], position , volume);
    }

    public void PlayPlayerFootSteps( Vector3 position ) {
        PlaySound( audioClipsRefSO.footstep, position );
    }

    public static SoundManager GetInstance() {
        return soundManager;    
    }
}
