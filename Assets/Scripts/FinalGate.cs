using UnityEngine;

public class FinalGate : MonoBehaviour
{
    public static FinalGate Instance;
    public GameObject finalGate;
    public AudioSource unlockSound;
    public GameObject endingTrigger;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void UnlockGate()
    {
        Debug.Log("All fragments collected. Unlocking gate!");
        finalGate.SetActive(false);
        endingTrigger.SetActive(true);
        unlockSound?.Play();
    }
}