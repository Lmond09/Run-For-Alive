using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject chestLid;
    public AudioSource openSound;
    private bool isOpened = false;
    public GameObject keyObject; // assign in Inspector

    public void Open()
    {
        if (isOpened) return;
        isOpened = true;

        Debug.Log("Chest Opened!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOpened && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Chest Touched");

            chestLid.transform.localPosition = new Vector3(0, 0.67f, -0.16f);
            chestLid.transform.localRotation = Quaternion.Euler(-45f, 0, 0);

            KeyTracker tracker = other.GetComponentInParent<KeyTracker>();
            if (tracker != null)
            {
                Open();
                keyObject.SetActive(true);
                //tracker.AddKey();
                openSound?.Play();
            }
        }
    }
}
