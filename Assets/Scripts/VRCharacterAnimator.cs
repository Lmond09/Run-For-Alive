using UnityEngine;

public class VRCharacterAnimator : MonoBehaviour
{
    public Animator animator;
    public Transform xrCamera;  // Main Camera

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = xrCamera.position;
    }

    void Update()
    {
        float moved = Vector3.Distance(xrCamera.position, lastPosition);
        lastPosition = xrCamera.position;

        bool isWalking = moved > 0.01f;
        animator.SetBool("IsWalking", isWalking);
    }
}
