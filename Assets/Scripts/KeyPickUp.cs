using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyPickup : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public AudioSource pickupSound;

    void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log("Key has been grabbed!");

        // Update key tracker
        KeyTracker tracker = FindObjectOfType<KeyTracker>();
        if (tracker != null)
            tracker.AddKey();
         pickupSound?.Play();
        // Optional: destroy or disable key after pickup
        Destroy(gameObject); // or SetActive(false)
    }
}
