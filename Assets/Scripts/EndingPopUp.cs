using System.Collections;
using UnityEngine;

public class EndingPopUp : MonoBehaviour
{
    public GameObject endingCanvas;
    public GameObject panel1;
    public GameObject panel2;
    public Transform playerCamera;
    public AudioSource audio;
    public Vector3 cameraOffset = new Vector3(0, 0, 0.5f);

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (endingCanvas != null && playerCamera != null)
            {
                endingCanvas.transform.SetParent(playerCamera);
                endingCanvas.transform.localPosition = cameraOffset;
                endingCanvas.transform.localRotation = Quaternion.identity;
                endingCanvas.SetActive(true);
                panel1.SetActive(true);
                panel2.SetActive(false);
            }
        }

        StartCoroutine(PerformNextPanel());
    }

    IEnumerator PerformNextPanel()
    {
        yield return new WaitForSeconds(3f);

        panel1.SetActive(false);
        audio?.Play();
        panel2.SetActive(true);
    }
}
