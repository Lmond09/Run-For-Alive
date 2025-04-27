using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    public AudioSource footstepSource;
    public float stepInterval = 0.5f; // seconds between steps
    private float stepTimer = 0f;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        float movement = Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;

        if (movement > 0.01f) // Only if moving
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                if (!footstepSource.isPlaying)
                    footstepSource.Play();

                stepTimer = stepInterval;
            }
        }
        else
        {
            // Immediately stop footstep sound if not moving
            if (footstepSource.isPlaying)
                footstepSource.Stop();

            stepTimer = 0f;
        }
    }
}
