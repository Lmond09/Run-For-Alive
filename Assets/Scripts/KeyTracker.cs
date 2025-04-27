using UnityEngine;

public class KeyTracker : MonoBehaviour
{
    public int collectedKey = 0;
    public FinalGate finalGate;
    public int totalKey = 3;

   public void AddKey()
{
    collectedKey++;
    Debug.Log($"You have collected {collectedKey} / {totalKey} keys");

    // UPDATE UI HERE
    var keyUI = FindObjectOfType<KeyCounterUI>();
    if (keyUI != null)
        keyUI.UpdateKeyDisplay(collectedKey);

    if (collectedKey >= totalKey)
    {
        FinalGate.Instance.UnlockGate();
    }
}

}
